package com.dfuse.wearcontrol;

import android.app.Fragment;
import android.app.FragmentManager;
import android.support.v13.app.FragmentPagerAdapter;

import java.util.ArrayList;

 class FragmentAdapter extends FragmentPagerAdapter {
	 private ArrayList<Fragment> mFragments;

	public FragmentAdapter(FragmentManager fm) {
		super(fm);
		mFragments = new ArrayList<Fragment>();
	}

	 @Override
     public Fragment getItem(int position) {
         return mFragments.get(position);
     }

     @Override
     public int getCount() {
         return mFragments.size();
     }


	public void addFragment(Fragment fragment) {
		// TODO Auto-generated method stub
		 mFragments.add(fragment);
         // Update the pager when adding a fragment.
         notifyDataSetChanged();
	}

}
