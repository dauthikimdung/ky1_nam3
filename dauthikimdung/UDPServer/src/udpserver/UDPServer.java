/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package udpserver;

/**
 *
 * @author Kim Dung
 */

import java.io.BufferedOutputStream;
import java.io.ByteArrayInputStream;
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.net.SocketException;

import common.FileInfo;

public class UDPServer {

    private static final int PIECES_OF_FILE_SIZE = 1024 * 32;
    private DatagramSocket serverSocket;
    private int port = 6677;

    /**
     * run program
     * 
     * @author viettuts.vn
     * @param args
     */
    public static void main(String[] args) {
        UDPServer udpServer = new UDPServer();
        udpServer.openServer();
    }
    
    /**
     * open server
     * 
     * @author viettuts.vn
     */
    private void openServer() {
        try {
            serverSocket = new DatagramSocket(port);
            System.out.println("Server is opened on port " + port);
            listening();
        } catch (SocketException e) {
            e.printStackTrace();
        }
    }

    /**
     * listening to clients handle events
     * 
     * @author viettuts.vn
     */
    private void listening() {
        while (true) {
            receiveFile();
        }
    }

    /**
     * receive file from clients
     * 
     * @author viettuts.vn
     */
    public void receiveFile() {
        byte[] receiveData = new byte[PIECES_OF_FILE_SIZE];
        DatagramPacket receivePacket;
        
        try {
            // Lấy thông tin file nhận
            receivePacket = new DatagramPacket(receiveData, receiveData.length);
            serverSocket.receive(receivePacket);
            InetAddress inetAddress = receivePacket.getAddress();
            ByteArrayInputStream bais = new ByteArrayInputStream(receivePacket.getData());
            ObjectInputStream ois = new ObjectInputStream(bais);
            FileInfo fileInfo = (FileInfo) ois.readObject();
            // Hiển thị thông tin file nhận
            if (fileInfo != null) {
                System.out.println("File name: " + fileInfo.getFilename());
                System.out.println("File size: " + fileInfo.getFileSize());
                System.out.println("Pieces of file: " + fileInfo.getPiecesOfFile());
                System.out.println("Last bytes length: " + fileInfo.getLastByteLength());
            }
            // get file content
            System.out.println("Receiving file...");
            File fileReceive = new File(fileInfo.getDestinationDirectory() 
                    + fileInfo.getFilename());
            BufferedOutputStream bos = new BufferedOutputStream(
                    new FileOutputStream(fileReceive));
            // Ghi từng phần của file nhận
            for (int i = 0; i < (fileInfo.getPiecesOfFile() - 1); i++) {
                receivePacket = new DatagramPacket(receiveData, receiveData.length, 
                        inetAddress, port);
                serverSocket.receive(receivePacket);
                bos.write(receiveData, 0, PIECES_OF_FILE_SIZE);
            }
            // Ghi những byte cuối của file nhận
            receivePacket = new DatagramPacket(receiveData, receiveData.length, 
                    inetAddress, port);
            serverSocket.receive(receivePacket);
            bos.write(receiveData, 0, fileInfo.getLastByteLength());
            bos.flush();
            System.out.println("Received file "+fileInfo.getFilename()+ " successfully!");

            // close stream
            bos.close();
        } catch (IOException e) {
            e.printStackTrace();
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }
    }
}
