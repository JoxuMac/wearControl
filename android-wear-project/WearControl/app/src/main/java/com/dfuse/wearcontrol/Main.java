/*
    Project: wearControl
    Author: Josue Gutierrez Duran
    WebPage:
    Class: MainActivity
 */

package com.dfuse.wearcontrol;

import android.app.Activity;
import android.content.SharedPreferences;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.os.Handler;
import android.support.v4.view.ViewPager;
import android.support.v4.view.ViewPager.OnPageChangeListener;
import android.support.wearable.view.DismissOverlayView;
import android.view.GestureDetector;
import android.view.MotionEvent;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.RelativeLayout;

public class Main extends Activity {

	private ViewPager mViewPager;
	private DismissOverlayView mDismissOverlayView;
	private GestureDetector mGestureDetector;
    private RelativeLayout mLayour;
    Button mPreSelectedBt;
    Button[] mPreSelectedBtArray;

    @Override
	protected void onCreate(Bundle dfuse) {

        SharedPreferences prefs = this.getSharedPreferences(
                "com.dfuse.wearcontrol", this.MODE_PRIVATE);
        if(prefs.getString("wearPIN", null)!=null)
            Params.PIN = prefs.getString("wearPIN", null);

		super.onCreate(dfuse);

        final UDPLink UDP = new UDPLink();
        Params.UDP = UDP;

        Thread thread = new Thread(new Runnable() {
            @Override
            public void run() {
            try {
                Params.UDP.Listen();
            } catch (Exception e) {
                e.printStackTrace();
            }
            }
        });

        thread.start();

		setContentView(R.layout.main);

		mDismissOverlayView = (DismissOverlayView) findViewById(R.id.dismiss);
		mDismissOverlayView.setIntroText(R.string.intro_text);
		mDismissOverlayView.showIntroIfNecessary();
		mViewPager = (ViewPager) findViewById(R.id.pager);

		final FragmentAdapter adapter = new FragmentAdapter(
				getFragmentManager());
		adapter.addFragment(new Media());
		adapter.addFragment(new Volume());
        Selector selector = new Selector();

		adapter.addFragment(selector);

        mLayour=(RelativeLayout)findViewById(R.id.layout);

        mViewPager.setAdapter(adapter);
		mViewPager.setOnPageChangeListener(new OnPageChangeListener() {

			@Override
			public void onPageSelected(int position) {
                if(mPreSelectedBt != null){
                    mPreSelectedBt.setBackgroundResource(android.R.drawable.radiobutton_off_background);
                }
                mPreSelectedBtArray[position].setBackgroundResource(android.R.drawable.radiobutton_on_background);

                for(int i =0 ;i<adapter.getCount();i++){
                    if(i!=position){
                        mPreSelectedBtArray[i].setBackgroundResource(android.R.drawable.radiobutton_off_background);
                    }
                }
                Handler handler = new Handler();
                handler.postDelayed(new Runnable() {
                    @Override
                    public void run() {
                        for(int i =0 ;i<adapter.getCount();i++){
                                mPreSelectedBtArray[i].setBackgroundResource(android.R.color.transparent);
                        }
                    }
                }, 2000);
            }

			@Override
			public void onPageScrolled(int position, float positionOffset,
					int positionOffsetPixels) {
			}

			@Override
			public void onPageScrollStateChanged(int state) {
			}
		});

		mGestureDetector = new GestureDetector(this, new LongPressListener());

        mPreSelectedBtArray = new Button[adapter.getCount()];

        Button btCent = new Button(this);
        btCent.setLayoutParams(new ViewGroup.LayoutParams(20,20));
        btCent.setBackgroundResource(android.R.drawable.radiobutton_off_background);
        mPreSelectedBtArray[adapter.getCount()/2] = btCent;
        mPreSelectedBtArray[adapter.getCount()/2].setId(adapter.getCount() / 2 + 1);
        RelativeLayout.LayoutParams layoutParamsCent = new RelativeLayout.LayoutParams(20,20);
        layoutParamsCent.addRule(RelativeLayout.CENTER_HORIZONTAL);
        layoutParamsCent.addRule(RelativeLayout.ALIGN_PARENT_BOTTOM);
        layoutParamsCent.setMargins(0,0,0,20);
        mLayour.addView(mPreSelectedBtArray[adapter.getCount()/2],layoutParamsCent);

        Bitmap bitmap = BitmapFactory.decodeResource(getResources(), android.R.drawable.radiobutton_off_background);
        for (int i = 0; i < adapter.getCount(); i++) {
            Button bt = new Button(this);
            bt.setLayoutParams(new ViewGroup.LayoutParams(20,20));
            bt.setBackgroundResource(android.R.drawable.radiobutton_off_background);
            if(i!=adapter.getCount()/2) {
                mPreSelectedBtArray[i] = bt;
                mPreSelectedBtArray[i].setId(i + 1);
            }
            RelativeLayout.LayoutParams layoutParams = new RelativeLayout.LayoutParams(20,20);
            if(i==adapter.getCount()/2){
                continue;
            }else if (i>adapter.getCount()/2){
                layoutParams.addRule(RelativeLayout.RIGHT_OF, i);
                layoutParams.addRule(RelativeLayout.ALIGN_TOP, i);
            }else if(i<adapter.getCount()/2){
                layoutParams.addRule(RelativeLayout.LEFT_OF, i+2);
                layoutParams.addRule(RelativeLayout.ALIGN_TOP, i+2);
            }
            mLayour.addView(mPreSelectedBtArray[i],layoutParams);
        }

        mPreSelectedBtArray[0].setBackgroundResource(android.R.drawable.radiobutton_on_background);

        for(int i =0 ;i<adapter.getCount();i++){
            mPreSelectedBtArray[i].setBackgroundResource(android.R.color.transparent);
        }

    }

	@Override
	public boolean dispatchTouchEvent(MotionEvent event) {
		return mGestureDetector.onTouchEvent(event)
				|| super.dispatchTouchEvent(event);
	}

	private class LongPressListener extends
			GestureDetector.SimpleOnGestureListener {
		@Override
		public void onLongPress(MotionEvent event) {}
	}

}
