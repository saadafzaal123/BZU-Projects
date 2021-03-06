/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package servergui;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.sql.Timestamp;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import javax.swing.JOptionPane;

/**
 *
 * @author Saad Afzaal
 */
public class ClientGroup extends javax.swing.JFrame 
{
    private String username;
    private String address;
    private String GroupName;
    private ArrayList<String> users = new ArrayList();
    private int port;
    private Boolean isConnected = false;
    
    private Socket sock;
    private BufferedReader reader;
    private PrintWriter writer;
    
    /**
     * Creates new form ClientGroup
     */
    public ClientGroup(String Username , String Title , String Address , int Port , String groupname) 
    {
        initComponents();
        
        setTitle(Title);
        
        username = Username;
        address = Address;
        port = Port;
        GroupName = groupname;
        
        tf_username.setText(username);
        tf_address.setText(address);
        String p = Integer.toString(port);
        tf_port.setText(p);
        
        tf_username.setEditable(false);
        tf_address.setEditable(false);
        tf_port.setEditable(false);
        b_disconnect.setEnabled(false);
        b_send.setEnabled(false);
        
        get_chatting();
    }
    
    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jLabel1 = new javax.swing.JLabel();
        tf_address = new javax.swing.JTextField();
        jLabel2 = new javax.swing.JLabel();
        tf_port = new javax.swing.JTextField();
        jLabel3 = new javax.swing.JLabel();
        tf_username = new javax.swing.JTextField();
        b_connect = new javax.swing.JButton();
        b_disconnect = new javax.swing.JButton();
        jScrollPane1 = new javax.swing.JScrollPane();
        ta_chat = new javax.swing.JTextArea();
        tf_chat = new javax.swing.JTextField();
        b_send = new javax.swing.JButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        jLabel1.setFont(new java.awt.Font("Tahoma", 0, 12)); // NOI18N
        jLabel1.setText("IPAddress  :");

        jLabel2.setFont(new java.awt.Font("Tahoma", 0, 12)); // NOI18N
        jLabel2.setText("Port          :");

        jLabel3.setFont(new java.awt.Font("Tahoma", 0, 12)); // NOI18N
        jLabel3.setText("Username  :");

        tf_username.setFont(new java.awt.Font("Tahoma", 0, 13)); // NOI18N

        b_connect.setFont(new java.awt.Font("Tahoma", 0, 12)); // NOI18N
        b_connect.setText("Connect");
        b_connect.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                b_connectActionPerformed(evt);
            }
        });

        b_disconnect.setFont(new java.awt.Font("Tahoma", 0, 12)); // NOI18N
        b_disconnect.setText("Disconnect");
        b_disconnect.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                b_disconnectActionPerformed(evt);
            }
        });

        ta_chat.setEditable(false);
        ta_chat.setColumns(20);
        ta_chat.setRows(5);
        jScrollPane1.setViewportView(ta_chat);

        tf_chat.setFont(new java.awt.Font("Tahoma", 1, 14)); // NOI18N

        b_send.setFont(new java.awt.Font("Tahoma", 0, 14)); // NOI18N
        b_send.setText("Send");
        b_send.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                b_sendActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(jScrollPane1)
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING, false)
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(jLabel2)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                                .addComponent(tf_port, javax.swing.GroupLayout.PREFERRED_SIZE, 100, javax.swing.GroupLayout.PREFERRED_SIZE))
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(jLabel1)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                                .addComponent(tf_address, javax.swing.GroupLayout.PREFERRED_SIZE, 100, javax.swing.GroupLayout.PREFERRED_SIZE)))
                        .addGap(71, 71, 71)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(jLabel3)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                                .addComponent(tf_username))
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(b_connect, javax.swing.GroupLayout.DEFAULT_SIZE, 99, Short.MAX_VALUE)
                                .addGap(12, 12, 12)
                                .addComponent(b_disconnect, javax.swing.GroupLayout.DEFAULT_SIZE, 112, Short.MAX_VALUE))))
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(tf_chat, javax.swing.GroupLayout.PREFERRED_SIZE, 347, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(b_send, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)))
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel1)
                    .addComponent(tf_address, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jLabel3)
                    .addComponent(tf_username, javax.swing.GroupLayout.PREFERRED_SIZE, 29, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel2)
                    .addComponent(tf_port, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(b_connect)
                    .addComponent(b_disconnect))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 336, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(tf_chat)
                    .addComponent(b_send, javax.swing.GroupLayout.DEFAULT_SIZE, 34, Short.MAX_VALUE))
                .addContainerGap())
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    public void get_chatting()
    {
        try
        {
            String url = "jdbc:derby://localhost:1527/MyDataBase";
            String uName = "Saad";
            String uPass= "03214061595";

            Connection con = DriverManager.getConnection(url , uName , uPass);
            
            String sql = "SELECT * FROM GROUP_CHATTING_MESSAGES where GROUP_NAME = '" + GroupName + "' ORDER BY ID ASC";
            Statement stat = con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_READ_ONLY);
            ResultSet rs = stat.executeQuery(sql);
            
            while(rs.next())
            {
                String msg = rs.getString("GROUP_MESSAGES");
                Date date = rs.getTimestamp("Date_Time");
                
                DateFormat dateFormat = new SimpleDateFormat("E h:mm a");
                
                String Date = dateFormat.format(date);
                
                ta_chat.append(msg + "  - - - - - - - -  " + dateFormat.format(date) + "\n\n");
            }
            
            stat.close();
            rs.close();
        }
        catch (SQLException se)
        {
            JOptionPane.showMessageDialog(null , se.getMessage());
        }
    }
    
    private void b_connectActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_b_connectActionPerformed
        // TODO add your handling code here:
        
        if (isConnected == false) 
        {
            //address = tf_address.getText();
            //String Port = tf_port.getText();
            //port = Integer.parseInt(Port);
            
            try 
            {
                sock = new Socket(address, port);
                InputStreamReader streamreader = new InputStreamReader(sock.getInputStream());
                reader = new BufferedReader(streamreader);
                writer = new PrintWriter(sock.getOutputStream());
                writer.println(username + ":has connected.:Connect");
                writer.flush(); 
                isConnected = true;
                
                b_send.setEnabled(true);
                b_disconnect.setEnabled(true);
            } 
            catch (Exception ex) 
            {
                ta_chat.append("Cannot Connect! Try Again. \n\n");
                tf_username.setEditable(true);
            }
            
            ListenThread();
        } 
        else if (isConnected == true) 
        {
            ta_chat.append("You are already connected. \n\n");
        }
    }//GEN-LAST:event_b_connectActionPerformed

    private void b_disconnectActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_b_disconnectActionPerformed
        // TODO add your handling code here:
        
        sendDisconnect();
        Disconnect();
        
        b_disconnect.setEnabled(false);
        b_send.setEnabled(false);
    }//GEN-LAST:event_b_disconnectActionPerformed

    private void b_sendActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_b_sendActionPerformed
        // TODO add your handling code here:
        
        String nothing = "";
        
        if ((tf_chat.getText()).equals(nothing)) 
        {
            tf_chat.setText("");
            tf_chat.requestFocus();
        } 
        else 
        {
            try 
            {
               DateFormat dateFormat = new SimpleDateFormat("E h:mm a");
               Date date = new Date();
               
               writer.println(username + "  :  " + tf_chat.getText() + ":" + "Chat");
               writer.flush(); // flushes the buffer
               
               String msg = username + "  :  " + tf_chat.getText();
               
               try
               {
                    String url = "jdbc:derby://localhost:1527/MyDataBase";
                    String uName = "Saad";
                    String uPass= "03214061595";

                    Connection con = DriverManager.getConnection(url , uName , uPass);
            
                    String sql = "SELECT * FROM COUNTER";
                    Statement stat = con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_READ_ONLY);
                    ResultSet rs = stat.executeQuery(sql);
                            
                    rs.absolute(1);
                    String count = rs.getString("GROUP_MSG_COUNTER");
                
                    stat.close();
                    rs.close();
                    
                    long Count = Long.valueOf(count).longValue();
                
                    Count++;
                    
                    String sql1 = "SELECT * FROM GROUP_CHATTING_MESSAGES";
                    Statement stat1 = con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_UPDATABLE);
                    ResultSet rs1 = stat1.executeQuery(sql1);
            
                    rs1.moveToInsertRow();
                    rs1.updateLong("ID",Count);
                    rs1.updateString("GROUP_NAME", GroupName);
                    rs1.updateString("GROUP_MESSAGES", msg);
                    rs1.updateTimestamp("DATE_TIME", new Timestamp(date.getTime()));
                    rs1.insertRow(); 
                
                    stat1.close();
                    rs1.close();
                    
                    String sql2 = "SELECT * FROM COUNTER";
                    Statement stat2 = con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_UPDATABLE);
                    ResultSet rs2 = stat2.executeQuery(sql2);
                    
                    String C = Long.toString(Count);
                    
                    rs2.absolute(1);
                    rs2.updateString("GROUP_MSG_COUNTER", C);
                    rs2.updateRow(); 
                    
                    stat2.close();
                    rs2.close();
               }
               catch (SQLException se)
               {
                    JOptionPane.showMessageDialog(null , se.getMessage());
               }     
            } 
            catch (Exception ex) 
            {
                ta_chat.append("Message was not sent. \n\n");
            }
            
            tf_chat.setText("");
            tf_chat.requestFocus();
        }

        tf_chat.setText("");
        tf_chat.requestFocus();
    }//GEN-LAST:event_b_sendActionPerformed

    public void ListenThread() 
    {
         Thread IncomingReader = new Thread(new IncomingReader());
         IncomingReader.start();
    }
    
    public void userAdd(String data) 
    {
         users.add(data);
    }
    
    public void userRemove(String data) 
    {
         ta_chat.append(data + " is now offline.\n\n");
    }
    
    public void writeUsers() 
    {
         String[] tempList = new String[(users.size())];
         users.toArray(tempList);
         
         for (String token:tempList) 
         {
             //users.append(token + "\n");
         }
    }
    
    public void sendDisconnect() 
    {
        String bye = (username + ": :Disconnect");
        
        try
        {
            writer.println(bye); 
            writer.flush(); 
        } 
        catch (Exception e) 
        {
            ta_chat.append("Could not send Disconnect message.\n\n");
        }
    }
    
    public void Disconnect() 
    {
        try 
        {
            ta_chat.append("Disconnected.\n\n");
            sock.close();
        } 
        catch(Exception ex) 
        {
            ta_chat.append("Failed to disconnect. \n\n");
        }
        
        isConnected = false;
        tf_username.setEditable(true);
    }
    
    public class IncomingReader implements Runnable
    {
        @Override
        public void run() 
        {
            String[] data;
            String stream, done = "Done", connect = "Connect", disconnect = "Disconnect", chat = "Chat";

            DateFormat dateFormat = new SimpleDateFormat("E h:mm a");
            Date date = new Date();
            
            try 
            {
                String format = "%-5s%s";
                String format2 = "%-80s%s";
                
                while ((stream = reader.readLine()) != null) 
                {
                     data = stream.split(":");

                     if (data[2].equals(chat)) 
                     {
                        String text1 = String.format(format , data[0] , "");
                        String text2 = String.format(format2 , data[1] , dateFormat.format(date));
                        //ta_chat.append(text1 + text2 + "\n");
                        ta_chat.append(data[0] + "  :  " + data[1] + "  - - - - - - - -  " + dateFormat.format(date) + "\n\n");
                        ta_chat.setCaretPosition(ta_chat.getDocument().getLength());
                     } 
                     else if (data[2].equals(connect))
                     {
                        ta_chat.removeAll();
                        userAdd(data[0]);
                     } 
                     else if (data[2].equals(disconnect)) 
                     {
                         userRemove(data[0]);
                     } 
                     else if (data[2].equals(done)) 
                     {
                        //users.setText("");
                        writeUsers();
                        users.clear();
                     }
                }
           }
           catch(Exception ex) 
           { 
               
           }
        }
    }
    
    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(ClientGroup.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(ClientGroup.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(ClientGroup.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(ClientGroup.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        //java.awt.EventQueue.invokeLater(new Runnable() {
           // public void run() {
           //     new ClientGroup("Saad Afzaal" , "10A" , "localhost" , 2222).setVisible(true);
          //  }
        //});
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton b_connect;
    private javax.swing.JButton b_disconnect;
    private javax.swing.JButton b_send;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JLabel jLabel3;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JTextArea ta_chat;
    private javax.swing.JTextField tf_address;
    private javax.swing.JTextField tf_chat;
    private javax.swing.JTextField tf_port;
    private javax.swing.JTextField tf_username;
    // End of variables declaration//GEN-END:variables
}
