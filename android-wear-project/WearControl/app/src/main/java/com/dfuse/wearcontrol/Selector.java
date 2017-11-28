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
import android.widget.ListView;
import android.widget.Toast;

public class Selector extends Fragment {
    ListView listView;
    Activity rootView;
    Activity context;

    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {

        final View rootView = inflater.inflate(R.layout.selector, container, false);
        context = getActivity();

        listView = (ListView) rootView.findViewById(R.id.selector_array);

        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view,
                                    int position, long id) {
               /* if (position == 0) {
                    Intent myIntent = new Intent(view.getContext(), ListItemActivity1.class);
                    startActivityForResult(myIntent, 0);
                }

                if (position == 1) {
                    Intent myIntent = new Intent(view.getContext(), ListItemActivity2.class);
                    startActivityForResult(myIntent, 0);
                }
*/
                if (position == 2) {
                    Intent intent = new Intent(getActivity(), Main2Activity.class);
                    ((MainActivity) getActivity()).startActivity(intent);


                   // Intent myIntent = new Intent(getActivity(), Main2Activity.class);
                    //startActivity(myIntent);
                }

                // ListView Clicked item value
                String itemValue = (String) listView.getItemAtPosition(position);

                // Show Alert
                Toast.makeText(context.getApplicationContext(), "Position :" + position + "  ListItem : " + itemValue, Toast.LENGTH_LONG).show();
            }
        });

        return rootView;
    }

    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        //you can set the title for your toolbar here for different fragments different titles
        getActivity().setTitle("XYZ");
    }


}