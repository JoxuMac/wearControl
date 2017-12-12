/*
    Project: wearControl
    Author: Josue Gutierrez Duran
    WebPage:
    Class: Selector
 */

package com.dfuse.wearcontrol;

import android.app.Activity;
import android.app.Fragment;
import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ImageView;
import android.widget.ListView;

public class Selector extends Fragment {
    ListView listView;
    Activity context;

    private ImageView image;

    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        final View rootView = inflater.inflate(R.layout.selector, container, false);
        context = getActivity();

        image = (ImageView) rootView.findViewById(R.id.imgCredits);
        image.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(final View v) {
                openCredits();
            }
        });

        image = (ImageView) rootView.findViewById(R.id.imgApps);
        image.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(final View v) {
                openApps(v);
            }
        });

        image = (ImageView) rootView.findViewById(R.id.imgConfig);
        image.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(final View v) {
                openConfig(v);
            }
        });

        listView = (ListView) rootView.findViewById(R.id.selector_array);

        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view,
                                    int position, long id) {
                if (position == 0)
                    openApps(view);

                if (position == 1)
                    openConfig(view);

                if (position == 2)
                    openCredits();

            }
        });
        return rootView;
    }

    public void clickApps(View view) {
        openApps(view);
    }

    public void clickCredits(View view) {
        openCredits();
    }

    public void clickConfig(View view) {
        openConfig(view);
    }

    private void openApps(View view){
        Intent myIntent = new Intent(view.getContext(), Apps.class);
        startActivityForResult(myIntent, 0);
    }

    private void openCredits(){
        Intent intent = new Intent(getActivity(), Credits.class);
        ((Main) getActivity()).startActivity(intent);
    }

    private void openConfig(View view){
        Intent myIntent = new Intent(view.getContext(), Configuration.class);
        startActivityForResult(myIntent, 0);
    }

    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        getActivity().setTitle("XYZ");
    }
}