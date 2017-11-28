package com.dfuse.wearcontrol;

import android.app.Fragment;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;

public class Media extends Fragment{

    private Button button;

       @Override
       public View onCreateView(LayoutInflater inflater, ViewGroup container,
                                Bundle savedInstanceState) {

           final View v = inflater.inflate(R.layout.media, container, false);

           button = (Button) v.findViewById(R.id.btnPlayPause);
           button.setOnClickListener(new View.OnClickListener() {
               @Override
               public void onClick(final View v) {
                   btnPlay_Pause(v);
               }
           });

           button = (Button) v.findViewById(R.id.btnStop);
           button.setOnClickListener(new View.OnClickListener() {
               @Override
               public void onClick(final View v) {
                   btnStop(v);
               }
           });

           button = (Button) v.findViewById(R.id.btnNext);
           button.setOnClickListener(new View.OnClickListener() {
               @Override
               public void onClick(final View v) {
                   btnNext(v);
               }
           });

           button = (Button) v.findViewById(R.id.btnPrevious);
           button.setOnClickListener(new View.OnClickListener() {
               @Override
               public void onClick(final View v) {
                   btnPrevious(v);
               }
           });

           return v;
       }

    public void btnPlay_Pause(View view) {
        Params.TCPConection.sendPlay();
        Log.e("onViewClicked", "PLAY / PAUSE");
    }

    public void btnStop(View view) {
        Params.TCPConection.sendStop();
        Log.e("onViewClicked", "STOP");
    }

    public void btnPrevious(View view) {
        Params.TCPConection.sendBack();
        Log.e("onViewClicked", "PREVIOUS");
    }

    public void btnNext(View view) {
        Params.TCPConection.sendNext();
        Log.e("onViewClicked", "NEXT");
    }

       public static void stopCycling() {}

   }
