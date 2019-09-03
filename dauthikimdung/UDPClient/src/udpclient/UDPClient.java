/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package udpclient;

/**
 *
 * @author Kim Dung
 */

import java.io.BufferedInputStream;
import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.ObjectOutputStream;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.net.SocketException;
import java.net.UnknownHostException;

import common.FileInfo;
public class UDPClient {

   private static final int PIECES_OF_FILE_SIZE = 1024 * 32;
    private DatagramSocket clientSocket;
    private int serverPort = 6677;
    private String serverHost = "localhost";
    
    public static void main(String[] args) {
        // Địa chỉ file gửi
        String sourcePath = "D:\\client\\test.zip";
        // Địa chỉ nhận file
        String destinationDir = "D:\\server\\";
        UDPClient udpClient = new UDPClient();
        udpClient.connectServer();
        udpClient.sendFile(sourcePath, destinationDir);
    }
    
    private void connectServer() {
        try {
            clientSocket = new DatagramSocket();
        } catch (SocketException e) {
            e.printStackTrace();
        }
    }

    private void sendFile(String sourcePath, String destinationDir) {
        InetAddress inetAddress;
        DatagramPacket sendPacket;
        String fileName = "";
        try {
            File fileSend = new File(sourcePath);
            fileName = fileSend.getName();
            InputStream inputStream = new FileInputStream(fileSend);
            BufferedInputStream bis = new BufferedInputStream(inputStream);
            inetAddress = InetAddress.getByName(serverHost);
            byte[] bytePart = new byte[PIECES_OF_FILE_SIZE];
            
            // get file size
            long fileLength = fileSend.length();
            int piecesOfFile = (int) (fileLength / PIECES_OF_FILE_SIZE);
            int lastByteLength = (int) (fileLength % PIECES_OF_FILE_SIZE);

            // check last bytes of file
            if (lastByteLength > 0) {
                piecesOfFile++;
            }

            // split file into pieces and assign to fileBytess
            byte[][] fileBytess = new byte[piecesOfFile][PIECES_OF_FILE_SIZE];
            int count = 0;
            while (bis.read(bytePart, 0, PIECES_OF_FILE_SIZE) > 0) {
                fileBytess[count++] = bytePart;
                bytePart = new byte[PIECES_OF_FILE_SIZE];
            }

            // read file info
            FileInfo fileInfo = new FileInfo();
            fileInfo.setFilename(fileSend.getName());
            fileInfo.setFileSize(fileSend.length());
            fileInfo.setPiecesOfFile(piecesOfFile);
            fileInfo.setLastByteLength(lastByteLength);
            fileInfo.setDestinationDirectory(destinationDir);

            // Gửi thông tin file
            ByteArrayOutputStream baos = new ByteArrayOutputStream();
            ObjectOutputStream oos = new ObjectOutputStream(baos);
            oos.writeObject(fileInfo);
            sendPacket = new DatagramPacket(baos.toByteArray(), baos.toByteArray().length,
                    inetAddress, serverPort);
            clientSocket.send(sendPacket);

            // Gửi nội dung file
            System.out.println("Sending file...");
            // Gửi từng phần của file
            for (int i = 0; i < (count - 1); i++) {
                sendPacket = new DatagramPacket(fileBytess[i], PIECES_OF_FILE_SIZE,
                        inetAddress, serverPort);
                clientSocket.send(sendPacket);
                waitMillisecond(40);
            }
            // Gửi những bytes cuối của file
            sendPacket = new DatagramPacket(fileBytess[count - 1], PIECES_OF_FILE_SIZE,
                    inetAddress, serverPort);
            clientSocket.send(sendPacket);
            waitMillisecond(40);

            // Đóng stream lại
            bis.close();
        } catch (UnknownHostException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
        System.out.println("The file "+ fileName +" is sent.");
    }
    // Dừng chương trình trong vài mili giây
    public void waitMillisecond(long millisecond) {
        try {
            Thread.sleep(millisecond);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }
    
}
