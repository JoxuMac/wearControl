/*
    Project: wearControl
    Author: Josue Gutierrez Duran
    WebPage:
    Class: Media
 */

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
        try{
            Params.UDP.sendPlay();
            Log.e("onViewClicked", "PLAY / PAUSE");
        }
            catch(Exception e) {
            System.out.print("Error: "+e);
        }
    }

    public void btnStop(View view) {
        try{
            Params.UDP.sendStop();
            Log.e("onViewClicked", "STOP");
        }
        catch(Exception e) {
            System.out.print("Error: "+e);
        }
    }

    public void btnPrevious(View view) {
        try{
            Params.UDP.sendBack();
            Log.e("onViewClicked", "PREVIOUS");
        }
        catch(Exception e) {
            System.out.print("Error: "+e);
        }
    }

    public void btnNext(View view) {
        try{
            Params.UDP.sendNext();
            Log.e("onViewClicked", "NEXT");
        }
        catch(Exception e) {
            System.out.print("Error: "+e);
        }
    }

       public static void stopCycling() {}

   }
