package com.dfuse.wearcontrol;

import android.content.Context;
import android.graphics.Typeface;

import java.util.Hashtable;

public class FontManager {

    private static Hashtable<String, Typeface> cached_icons = new Hashtable<>();

    public static Typeface get_icons (String path, Context context){

        Typeface icons = cached_icons.get(path);

        if(icons==null){
            icons = Typeface.createFromAsset(context.getAssets(), path);
            cached_icons.put(path, icons);
        }
        return icons;
    }

    /*
    public static final String ROOT = "fonts/",
            FONTAWESOME = ROOT + "fontawesome-webfont.ttf";

    public static Typeface getTypeface(Context context, String font) {
        return Typeface.createFromAsset(context.getAssets(), font);
    }

    public static void markAsIconContainer(View v, Typeface typeface) {
        if (v instanceof ViewGroup) {
            ViewGroup vg = (ViewGroup) v;
            for (int i = 0; i < vg.getChildCount(); i++) {
                View child = vg.getChildAt(i);
                markAsIconContainer(child, typeface);
            }
        } else if (v instanceof TextView) {
            ((TextView) v).setTypeface(typeface);
        }
    }
*/
}