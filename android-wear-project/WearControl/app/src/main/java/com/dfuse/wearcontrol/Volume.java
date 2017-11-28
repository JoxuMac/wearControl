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
        Params.TCPConection.sendMute();
        Log.e("onViewClicked", "MUTE / UNMUTE");
    }

    public void btnVolUp(View view) {
        Params.TCPConection.sendVolUp();
        Log.e("onViewClicked", "VOL UP");
    }

    public void btnVolDown(View view) {
        Params.TCPConection.sendVolDown();
        Log.e("onViewClicked", "VOL DOWN");
    }

	public void startCycling() {}

}

