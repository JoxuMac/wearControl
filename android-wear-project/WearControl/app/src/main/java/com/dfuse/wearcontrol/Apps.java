/*
    Project: wearControl
    Author: Josue Gutierrez Duran
    WebPage:
    Class: Apps
 */

package com.dfuse.wearcontrol;

import android.app.Activity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;

public class Apps extends Activity {

    ListView listView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.apps);

        listView = (ListView) this.findViewById(R.id.selector_array);

        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view,
                                    int position, long id) {
                if (position == 0)
                    sendVLC();

                if (position == 1)
                    sendSpotify();

                if (position == 2)
                    sendiTunes();
            }
        });
    }

    public void clickVLC(View view) {
        sendVLC();
    }

    public void clickSpotify(View view) {
        sendSpotify();
    }

    public void clickiTunes(View view) {
        sendiTunes();
    }

    private void sendSpotify(){
        try{
            Params.UDP.sendSpotify();
            Log.e("onViewClicked", "Spotify");
        }
        catch(Exception e) {
            System.out.print("Error: "+e);
        }
    }

    private void sendVLC(){
        try{
            Params.UDP.sendVLC();
            Log.e("onViewClicked", "VLC");
        }
        catch(Exception e) {
            System.out.print("Error: "+e);
        }
    }

    private void sendiTunes(){
        try{
            Params.UDP.sendiTunes();
            Log.e("onViewClicked", "iTunes");
        }
        catch(Exception e) {
            System.out.print("Error: "+e);
        }
    }
}