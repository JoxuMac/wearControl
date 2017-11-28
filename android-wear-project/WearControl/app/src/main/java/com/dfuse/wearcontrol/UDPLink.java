package com.dfuse.wearcontrol;

import java.net.*;

public class UDPLink {

    int port = 11000;

    public UDPLink(){

    }

    public void sendPIN(int PIN) throws Exception {

        //BufferedReader inFromUser = new BufferedReader(new InputStreamReader(System.in));
        DatagramSocket clientSocket = new DatagramSocket();

        	InetAddress IPAddress = InetAddress.getByName("255.255.255.255"); // BROADCAST ??
       // InetAddress IPAddress = InetAddress.getByName("localhost");

        byte[] sendData = new byte[1024];
        byte[] receiveData = new byte[1024];

        //String sentence = inFromUser.readLine();
        //sendData = sentence.getBytes();
        sendData = Integer.toString(PIN).getBytes();



        DatagramPacket sendPacket = new DatagramPacket(sendData, sendData.length, IPAddress, port);
        clientSocket.send(sendPacket);

        DatagramPacket receivePacket = new DatagramPacket(receiveData, receiveData.length);
        clientSocket.receive(receivePacket);

        String modifiedSentence = new String(receivePacket.getData());
        System.out.println("FROM SERVER:" + modifiedSentence);
        clientSocket.close();
    }

}
