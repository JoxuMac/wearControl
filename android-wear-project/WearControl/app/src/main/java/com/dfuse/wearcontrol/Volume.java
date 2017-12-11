/*
    Project: wearControl
    Author: Josue Gutierrez Duran
    WebPage:
    Class: Volume
 */

package com.dfuse.wearcontrol;

import android.app.Fragment;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;

public class Volume extends Fragment{

    private Button button;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
            Bundle savedInstanceState) {

        final View v = inflater.inflate(R.layout.volume, container, false);

        button = (Button) v.findViewById(R.id.btnMute);
        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(final View v) {
                btnMute_Unmute(v);
            }
        });

        button = (Button) v.findViewById(R.id.btnVolumeUp);
        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(final View v) {
                btnVolUp(v);
            }
        });

        button = (Button) v.findViewById(R.id.btnVolumeDown);
        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(final View v) {
                btnVolDown(v);
            }
        });

        return v;
    }

    public void btnMute_Unmute(View view) {
        try {
            Params.UDP.sendMute();
            Log.e("onViewClicked", "MUTE / UNMUTE");
        }
        catch(Exception e) {
            Log.e("error", e.getMessage()+"ERROR MUTE / UNMUTE"+e);
        }
    }

    public void btnVolUp(View view) {
        try{
            Params.UDP.sendVolUp();
            Log.e("onViewClicked", "VOL UP");
        }
            catch(Exception e) {
            System.out.print("Error: "+e);
        }
    }

    public void btnVolDown(View view) {
        try{
            Params.UDP.sendVolDown();
            Log.e("onViewClicked", "VOL DOWN");
        }
        catch(Exception e) {
                System.out.print("Error: "+e);
                }
    }

	public void startCycling() {}

}

