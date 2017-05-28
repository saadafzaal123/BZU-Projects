/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package servergui;

import java.awt.*;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import javax.swing.*;

/**
 *
 * @author Saad Afzaal
 */
public class ServerGUI implements Runnable 
{
    private String Username;
    private String Receivername;
    private String UserNo;
    private String ReceiverNo;
    
    public ServerGUI(String username , String receivername , String userNo , String receiverNo)
    {
        Username = username;
        Receivername = receivername;
        UserNo = userNo;
        ReceiverNo = receiverNo;
    }
    
    /**8
     * @param args the command line arguments
     */
    
    public void run()
    {
        Thread serverThread = new Thread(new Runnable()
        {
           public void run()
           {
               Server saad = new Server(Username , Receivername , UserNo , ReceiverNo);
               saad.setVisible(true);
               saad.setDefaultCloseOperation(JFrame.DO_NOTHING_ON_CLOSE);
               saad.setSize(410,450); 
           }
        });
             
        serverThread.start();
      
        // wait a bit
        try
        {
            Thread.sleep(1000);
        }
        catch(Exception e)
        {
            
        }
    }
    
    public static void main(String[] args) 
    {
        // TODO code application logic here
        ServerGUI S = new ServerGUI("Server" , "MY Server" , "###" , "###");
        Thread ST = new Thread(S);
        ST.start();
    }   
}
