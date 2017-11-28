package com.dfuse.wearcontrol;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.support.wearable.view.DismissOverlayView;
import android.view.GestureDetector;
import android.view.View;

public class Main2Activity extends Activity {

    private DismissOverlayView mDismissOverlayView;
    private GestureDetector mGestureDetector;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main2);


    }
    public void btnBack (View view) {
        Intent intent=new Intent(Main2Activity.this, MainActivity.class);
        startActivityForResult(intent, 2);// Activity is started with requestCode 2
    }
}
