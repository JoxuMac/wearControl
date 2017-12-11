package com.dfuse.wearcontrol;

import android.app.Activity;
import android.os.Bundle;
import android.widget.SeekBar;
import android.widget.TextView;
import android.content.SharedPreferences;

public class Configuration extends Activity {

    private SeekBar skbPIN1;
    private SeekBar skbPIN2;
    private SeekBar skbPIN3;
    private SeekBar skbPIN4;
    private TextView txvPIN;


    @Override
    protected void onCreate(Bundle dfuse) {
        super.onCreate(dfuse);
        setContentView(R.layout.configuration);
        initializeVariables();

        txvPIN.setText("PIN: " + skbPIN1.getProgress() + skbPIN2.getProgress() + skbPIN3.getProgress() + skbPIN4.getProgress());

        SeekBar.OnSeekBarChangeListener listener = new SeekBar.OnSeekBarChangeListener() {
            @Override
            public void onProgressChanged(SeekBar seekBar, int progresValue, boolean fromUser) {
                txvPIN.setText("PIN: " + skbPIN1.getProgress() + skbPIN2.getProgress() + skbPIN3.getProgress() + skbPIN4.getProgress());
                Params.PIN = String.valueOf(skbPIN1.getProgress()) + String.valueOf(skbPIN2.getProgress()) + String.valueOf(skbPIN3.getProgress()) + String.valueOf(skbPIN4.getProgress());

                SharedPreferences pref = getApplicationContext().getSharedPreferences("com.dfuse.wearcontrol", 0);
                SharedPreferences.Editor editor = pref.edit();
                editor.putString("wearPIN", Params.PIN);
            }

            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {}

            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {}
        };

        skbPIN1.setOnSeekBarChangeListener(listener);
        skbPIN2.setOnSeekBarChangeListener(listener);
        skbPIN3.setOnSeekBarChangeListener(listener);
        skbPIN4.setOnSeekBarChangeListener(listener);
   }

    private void initializeVariables() {
        skbPIN1 = (SeekBar) findViewById(R.id.skbPIN1);
        skbPIN2 = (SeekBar) findViewById(R.id.skbPIN2);
        skbPIN3 = (SeekBar) findViewById(R.id.skbPIN3);
        skbPIN4 = (SeekBar) findViewById(R.id.skbPIN4);
        txvPIN = (TextView) findViewById(R.id.txvPIN);

        skbPIN1.setProgress(Character.getNumericValue(Params.PIN.charAt(0)));
        skbPIN2.setProgress(Character.getNumericValue(Params.PIN.charAt(1)));
        skbPIN3.setProgress(Character.getNumericValue(Params.PIN.charAt(2)));
        skbPIN4.setProgress(Character.getNumericValue(Params.PIN.charAt(3)));
    }
}
