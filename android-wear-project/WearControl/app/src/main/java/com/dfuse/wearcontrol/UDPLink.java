/*
    Project: wearControl
    Author: Josue Gutierrez Duran
    WebPage:
    Class: UDPLink
 */

package com.dfuse.wearcontrol;

import android.os.StrictMode;
import java.net.*;


public class UDPLink {
    private String data;

    public void Listen(){
        String msg = "0";
        try {
            DatagramSocket dsocket = new DatagramSocket(Params.socketListener);
            byte[] buffer = new byte[2048];
            DatagramPacket packet = new DatagramPacket(buffer, buffer.length);

            dsocket.receive(packet);
            msg = new String(buffer, 0, packet.getLength());

            System.out.println(packet.getAddress().getHostName() + ": "
                    + msg);

            packet.setLength(buffer.length);

            Params.ip = packet.getAddress().getHostAddress();
        } catch (Exception e) {
            System.err.println(e);
        }
    }

    public void sendData(String data) throws Exception {
        DatagramSocket clientSocket = new DatagramSocket();
        InetAddress IPAddress = InetAddress.getByName(Params.ip);
        byte[] sendData = new byte[1024];
        data = "1234-" + data;
        sendData = data.getBytes();
        DatagramPacket sendPacket = new DatagramPacket(sendData, sendData.length, IPAddress, Params.socketSender);

        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();

        StrictMode.setThreadPolicy(policy);
        clientSocket.send(sendPacket);
        clientSocket.close();
    }

    public void sendPlay() throws Exception {
        sendData("0000");
    }

    public void sendNext() throws Exception {
        sendData("0010");
    }

    public void sendBack() throws Exception {
        sendData("0011");
    }

    public void sendVolUp()throws Exception {
        sendData("0101");
    }

    public void sendVolDown()throws Exception {
        sendData("0110");
    }

    public void sendMute()throws Exception {
        sendData("0100");
    }

    public void sendStop() throws Exception {
        sendData("0001");
    }

    public void sendSpotify()throws Exception {
        sendData("0111");
    }

    public void sendVLC()throws Exception {
        sendData("1001");
    }

    public void sendiTunes()throws Exception {
        sendData("1000");
    }
}