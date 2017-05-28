/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package servergui;

import javax.swing.JFrame;

/**
 *
 * @author Saad Afzaal
 */
public class ClientGUI implements Runnable
{
    private String Username;
    private String Receivername;
    private String UserNo;
    private String ReceiverNo;
    
    public ClientGUI(String username , String receivername , String userNo , String receiverNo)
    {
        Username = username;
        Receivername = receivername;
        UserNo = userNo;
        ReceiverNo = receiverNo;
    }
    
    public void run()
    {        
        Thread clientThread = new Thread(new Runnable()
        {
           public void run()
           {
               
               Client amjad = new Client(Username , Receivername , UserNo , ReceiverNo);
               amjad.setVisible(true);
               amjad.setDefaultCloseOperation(JFrame.DO_NOTHING_ON_CLOSE);
               amjad.setSize(410,450);
           }
        });
             
        clientThread.start();
      
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
        ClientGUI C = new ClientGUI("Client" , "MY Client" , "###" , "###");
        Thread CT = new Thread(C);
        CT.start();
    }
}
