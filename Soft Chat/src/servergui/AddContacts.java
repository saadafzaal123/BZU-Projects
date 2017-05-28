/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package servergui;

import java.awt.Color;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import javax.swing.JFrame;
import javax.swing.JOptionPane;

/**
 *
 * @author Amjad Afzaal
 */
public class AddContacts extends javax.swing.JFrame {

    String Username;
    /**
     * Creates new form AddContacts
     */
    public AddContacts(String username) {
        initComponents();
        
        Username = username;
        
        AddContacts_Label.setForeground(Color.blue);
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
        LogOut_Label = new javax.swing.JLabel();
        AddContacts_Label = new javax.swing.JLabel();
        Chat_Label = new javax.swing.JLabel();
        Contacts_Label = new javax.swing.JLabel();
        jLabel6 = new javax.swing.JLabel();
        jLabel7 = new javax.swing.JLabel();
        jLabel8 = new javax.swing.JLabel();
        NameTxtBox = new javax.swing.JTextField();
        ContactNumberTxtBox = new javax.swing.JTextField();
        EmailTxtBox = new javax.swing.JTextField();
        AddContact_Button = new javax.swing.JButton();
        DeleteContacts_Label = new javax.swing.JLabel();
        EditContacts_Label = new javax.swing.JLabel();
        NewGroup_Label = new javax.swing.JLabel();
        MyGroups_Label = new javax.swing.JLabel();
        Groups_Label = new javax.swing.JLabel();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setTitle("AddContacts");

        jLabel1.setFont(new java.awt.Font("Tahoma", 1, 18)); // NOI18N
        jLabel1.setText("SoftChat");

        LogOut_Label.setFont(new java.awt.Font("Tahoma", 0, 12)); // NOI18N
        LogOut_Label.setText("LogOut");
        LogOut_Label.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                LogOut_LabelMouseClicked(evt);
            }
            public void mouseEntered(java.awt.event.MouseEvent evt) {
                LogOut_LabelMouseEntered(evt);
            }
            public void mouseExited(java.awt.event.MouseEvent evt) {
                LogOut_LabelMouseExited(evt);
            }
        });

        AddContacts_Label.setFont(new java.awt.Font("Tahoma", 0, 12)); // NOI18N
        AddContacts_Label.setText("AddContacts");
        AddContacts_Label.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                AddContacts_LabelMouseClicked(evt);
            }
            public void mouseEntered(java.awt.event.MouseEvent evt) {
                AddContacts_LabelMouseEntered(evt);
            }
        });

        Chat_Label.setFont(new java.awt.Font("Tahoma", 1, 15)); // NOI18N
        Chat_Label.setText("CHAT");
        Chat_Label.setBorder(javax.swing.BorderFactory.createTitledBorder(""));
        Chat_Label.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                Chat_LabelMouseClicked(evt);
            }
            public void mouseEntered(java.awt.event.MouseEvent evt) {
                Chat_LabelMouseEntered(evt);
            }
            public void mouseExited(java.awt.event.MouseEvent evt) {
                Chat_LabelMouseExited(evt);
            }
        });

        Contacts_Label.setFont(new java.awt.Font("Tahoma", 1, 15)); // NOI18N
        Contacts_Label.setText("CONTACTS");
        Contacts_Label.setBorder(javax.swing.BorderFactory.createTitledBorder(""));
        Contacts_Label.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                Contacts_LabelMouseClicked(evt);
            }
            public void mouseEntered(java.awt.event.MouseEvent evt) {
                Contacts_LabelMouseEntered(evt);
            }
            public void mouseExited(java.awt.event.MouseEvent evt) {
                Contacts_LabelMouseExited(evt);
            }
        });

        jLabel6.setFont(new java.awt.Font("Tahoma", 0, 15)); // NOI18N
        jLabel6.setText("Name  :");

        jLabel7.setFont(new java.awt.Font("Tahoma", 0, 15)); // NOI18N
        jLabel7.setText("ContactNo  :");

        jLabel8.setFont(new java.awt.Font("Tahoma", 0, 15)); // NOI18N
        jLabel8.setText("Email  :");

        NameTxtBox.setFont(new java.awt.Font("Tahoma", 0, 15)); // NOI18N

        ContactNumberTxtBox.setFont(new java.awt.Font("Tahoma", 0, 15)); // NOI18N

        EmailTxtBox.setFont(new java.awt.Font("Tahoma", 0, 15)); // NOI18N

        AddContact_Button.setFont(new java.awt.Font("Tahoma", 0, 15)); // NOI18N
        AddContact_Button.setText("AddContact");
        AddContact_Button.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                AddContact_ButtonActionPerformed(evt);
            }
        });

        DeleteContacts_Label.setFont(new java.awt.Font("Tahoma", 0, 12)); // NOI18N
        DeleteContacts_Label.setText("DeleteContacts");
        DeleteContacts_Label.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                DeleteContacts_LabelMouseClicked(evt);
            }
            public void mouseEntered(java.awt.event.MouseEvent evt) {
                DeleteContacts_LabelMouseEntered(evt);
            }
            public void mouseExited(java.awt.event.MouseEvent evt) {
                DeleteContacts_LabelMouseExited(evt);
            }
        });

        EditContacts_Label.setFont(new java.awt.Font("Tahoma", 0, 12)); // NOI18N
        EditContacts_Label.setText("EditContacts");
        EditContacts_Label.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                EditContacts_LabelMouseClicked(evt);
            }
            public void mouseEntered(java.awt.event.MouseEvent evt) {
                EditContacts_LabelMouseEntered(evt);
            }
            public void mouseExited(java.awt.event.MouseEvent evt) {
                EditContacts_LabelMouseExited(evt);
            }
        });

        NewGroup_Label.setFont(new java.awt.Font("Tahoma", 0, 12)); // NOI18N
        NewGroup_Label.setText("NewGroup");
        NewGroup_Label.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                NewGroup_LabelMouseClicked(evt);
            }
            public void mouseEntered(java.awt.event.MouseEvent evt) {
                NewGroup_LabelMouseEntered(evt);
            }
            public void mouseExited(java.awt.event.MouseEvent evt) {
                NewGroup_LabelMouseExited(evt);
            }
        });

        MyGroups_Label.setFont(new java.awt.Font("Tahoma", 0, 12)); // NOI18N
        MyGroups_Label.setText("MyGroups");
        MyGroups_Label.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                MyGroups_LabelMouseClicked(evt);
            }
            public void mouseEntered(java.awt.event.MouseEvent evt) {
                MyGroups_LabelMouseEntered(evt);
            }
            public void mouseExited(java.awt.event.MouseEvent evt) {
                MyGroups_LabelMouseExited(evt);
            }
        });

        Groups_Label.setFont(new java.awt.Font("Tahoma", 0, 12)); // NOI18N
        Groups_Label.setText("Groups");
        Groups_Label.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                Groups_LabelMouseClicked(evt);
            }
            public void mouseEntered(java.awt.event.MouseEvent evt) {
                Groups_LabelMouseEntered(evt);
            }
            public void mouseExited(java.awt.event.MouseEvent evt) {
                Groups_LabelMouseExited(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(jLabel1)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 59, Short.MAX_VALUE)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                        .addComponent(DeleteContacts_Label)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addComponent(AddContacts_Label)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addComponent(LogOut_Label)
                        .addContainerGap())
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                        .addComponent(Groups_Label)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addComponent(MyGroups_Label)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addComponent(NewGroup_Label)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addComponent(EditContacts_Label)
                        .addGap(33, 33, 33))))
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                    .addGroup(javax.swing.GroupLayout.Alignment.LEADING, layout.createSequentialGroup()
                        .addGap(68, 68, 68)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(jLabel6, javax.swing.GroupLayout.Alignment.TRAILING)
                            .addComponent(jLabel8, javax.swing.GroupLayout.Alignment.TRAILING)
                            .addComponent(jLabel7, javax.swing.GroupLayout.Alignment.TRAILING))
                        .addGap(18, 18, 18)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(AddContact_Button)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 107, Short.MAX_VALUE))
                            .addComponent(NameTxtBox)
                            .addComponent(ContactNumberTxtBox)
                            .addComponent(EmailTxtBox)))
                    .addGroup(javax.swing.GroupLayout.Alignment.LEADING, layout.createSequentialGroup()
                        .addGap(44, 44, 44)
                        .addComponent(Chat_Label)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .addComponent(Contacts_Label)))
                .addGap(45, 45, 45))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(jLabel1)
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(LogOut_Label)
                            .addComponent(AddContacts_Label)
                            .addComponent(DeleteContacts_Label))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(EditContacts_Label)
                            .addComponent(NewGroup_Label)
                            .addComponent(MyGroups_Label)
                            .addComponent(Groups_Label))))
                .addGap(12, 12, 12)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(Chat_Label)
                    .addComponent(Contacts_Label))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 53, Short.MAX_VALUE)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel6)
                    .addComponent(NameTxtBox, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(ContactNumberTxtBox, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jLabel7))
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(EmailTxtBox, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jLabel8))
                .addGap(28, 28, 28)
                .addComponent(AddContact_Button, javax.swing.GroupLayout.PREFERRED_SIZE, 31, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(44, 44, 44))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private String get_No()
    {
        try
        {
            String url = "jdbc:derby://localhost:1527/MyDataBase";
            String uName = "Saad";
            String uPass= "03214061595";

            Connection con = DriverManager.getConnection(url , uName , uPass);
            
            String sql = "SELECT * FROM ACCOUNTS where USERNAME = '" + Username + "'";
            Statement stat = con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_READ_ONLY);
            ResultSet rs = stat.executeQuery(sql);
            
            
            rs.first();
            String myno = rs.getString("PHONENO");
            
            stat.close();
            rs.close();
            
            return myno;
        }
        catch (SQLException se)
        {
            JOptionPane.showMessageDialog(null , se.getMessage());
            return null;
        }
    }
    
    private void LogOut_LabelMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_LogOut_LabelMouseClicked
        // TODO add your handling code here:
        
        try
        {
            String url = "jdbc:derby://localhost:1527/MyDataBase";
            String uName = "Saad";
            String uPass= "03214061595";

            Connection con = DriverManager.getConnection(url , uName , uPass);
            
            String sql = "SELECT * FROM SESSION where USERNAME = '" + Username + "'";
            Statement stat = con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_UPDATABLE);
            ResultSet rs = stat.executeQuery(sql);
            
            rs.first();
            rs.updateBoolean("SESSION_ID", false);
            rs.updateRow();
            
            /*String sql1 = "SELECT * FROM LOGGINCHECK where ISLOGGIN = '" + "Yes" + "'";
            Statement stat1 = con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_UPDATABLE);
            ResultSet rs1= stat1.executeQuery(sql1);
            
            rs1.absolute(1);
            rs1.deleteRow();
            
            stat1.close();
            rs1.close();*/
            
            ChatSoft cs = new ChatSoft();
            cs.setVisible(true);
            cs.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            this.setVisible(false);
        }
        catch (SQLException se)
        {
            JOptionPane.showMessageDialog(null , se.getMessage());
        }         
    }//GEN-LAST:event_LogOut_LabelMouseClicked

    private void LogOut_LabelMouseEntered(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_LogOut_LabelMouseEntered
        // TODO add your handling code here:
        
        LogOut_Label.setBackground(Color.blue);
        LogOut_Label.setForeground(Color.blue);
    }//GEN-LAST:event_LogOut_LabelMouseEntered

    private void LogOut_LabelMouseExited(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_LogOut_LabelMouseExited
        // TODO add your handling code here:
        
        LogOut_Label.setBackground(Color.gray);
        LogOut_Label.setForeground(Color.black);
    }//GEN-LAST:event_LogOut_LabelMouseExited

    private void AddContacts_LabelMouseEntered(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_AddContacts_LabelMouseEntered
        // TODO add your handling code here:
        
        AddContacts_Label.setForeground(Color.blue);
    }//GEN-LAST:event_AddContacts_LabelMouseEntered

    private void Chat_LabelMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_Chat_LabelMouseClicked
        // TODO add your handling code here:
        
        Chat c;
        c = new Chat(Username);
        c.setVisible(true);
        c.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setVisible(false);
    }//GEN-LAST:event_Chat_LabelMouseClicked

    private void Chat_LabelMouseEntered(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_Chat_LabelMouseEntered
        // TODO add your handling code here:
        
        Chat_Label.setBackground(Color.blue);
        Chat_Label.setForeground(Color.blue);
    }//GEN-LAST:event_Chat_LabelMouseEntered

    private void Chat_LabelMouseExited(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_Chat_LabelMouseExited
        // TODO add your handling code here:
        
        Chat_Label.setBackground(Color.gray);
        Chat_Label.setForeground(Color.black);
    }//GEN-LAST:event_Chat_LabelMouseExited

    private void Contacts_LabelMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_Contacts_LabelMouseClicked
        // TODO add your handling code here:
        
        Contacts c = new Contacts(Username);
        c.setVisible(true);
        c.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setVisible(false);
    }//GEN-LAST:event_Contacts_LabelMouseClicked

    private void Contacts_LabelMouseEntered(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_Contacts_LabelMouseEntered
        // TODO add your handling code here:
        
        Contacts_Label.setBackground(Color.blue);
        Contacts_Label.setForeground(Color.blue);
    }//GEN-LAST:event_Contacts_LabelMouseEntered

    private void Contacts_LabelMouseExited(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_Contacts_LabelMouseExited
        // TODO add your handling code here:
        
        Contacts_Label.setBackground(Color.gray);
        Contacts_Label.setForeground(Color.black);
    }//GEN-LAST:event_Contacts_LabelMouseExited

    private void AddContact_ButtonActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_AddContact_ButtonActionPerformed
        // TODO add your handling code here:
        
        String name = NameTxtBox.getText();
        String contactnumber = ContactNumberTxtBox.getText();
        String email = EmailTxtBox.getText();
        
        if(name.equals("") || contactnumber.equals(""))
        {
            JOptionPane.showMessageDialog(null , "Name and Contact-Number must Required!");
        }
        else
        {
            try
            {
                String url = "jdbc:derby://localhost:1527/MyDataBase";
                String uName = "Saad";
                String uPass= "03214061595";

                Connection con = DriverManager.getConnection(url , uName , uPass);
            
                String sql = "SELECT * FROM ACCOUNTS where PHONENO = '" + contactnumber +"'";
                Statement stat = con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_READ_ONLY);
                ResultSet rs = stat.executeQuery(sql);
                
                rs.first();
                String PhoneNo = rs.getString("PHONENO");
                
                if(PhoneNo.equals(""))
                {
                    JOptionPane.showMessageDialog(null , "This Contact-Number is not on SoftChat!");
                }
                else
                {
                    try
                    {
                        String sql2 = "SELECT * from CONTACTS where (USERNAME = '" + Username +"' AND NAME = '" + name +"') OR (USERNAME = '" + Username +"' AND PHONENO = '" + contactnumber +"')";
                        Statement stat2 = con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_READ_ONLY);
                        ResultSet rs2 = stat2.executeQuery(sql2);
                        
                        rs2.first();
                        
                        String Name = rs2.getString("NAME");
                         
                        if(!(Name.equals("")))
                        {
                             JOptionPane.showMessageDialog(null , "Name Dublictaed! OR Already you save this contact no with other name.");
                        }
                    }
                    catch(SQLException se)
                    {
                        String M_No = get_No();
                        
                        try
                        {   
                            String sql4 = "SELECT * FROM CONTACTS where PHONENO = '" + M_No + "' AND USER_PHONENO = '" + contactnumber + "'";
                            Statement stat4 = con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_READ_ONLY);
                            ResultSet rs4 = stat4.executeQuery(sql4);
                            
                            rs4.absolute(1);
                            int Port = rs4.getInt("PORT");
                
                            stat4.close();
                            rs4.close();
                            
                            
                            String sql1 = "SELECT * FROM CONTACTS";
                            Statement stat1 = con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_UPDATABLE);
                            ResultSet rs1 = stat1.executeQuery(sql1);
                        
                            rs1.moveToInsertRow();
                            rs1.updateString("USERNAME",Username);
                            rs1.updateString("NAME", name);
                            rs1.updateString("PHONENO", contactnumber);
                            rs1.updateString("EMAIL", email);
                            rs1.updateString("USER_PHONENO", M_No);
                            rs1.updateInt("PORT", Port);
                            rs1.insertRow();
                            
                            stat1.close();
                            rs1.close();
                            
                            JOptionPane.showMessageDialog(null , "Contact No added Successfully!");
                        
                            NameTxtBox.setText("");
                            ContactNumberTxtBox.setText("");
                            EmailTxtBox.setText("");
                            
                        }
                        catch(SQLException s)
                        {
                            String sql2 = "SELECT * FROM COUNTER";
                            Statement stat2 = con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_READ_ONLY);
                            ResultSet rs2 = stat2.executeQuery(sql2);
                            
                            rs2.absolute(1);
                            int port = rs2.getInt("CONTACT_PORT");
                
                            stat2.close();
                            rs2.close();
                
                            port++;
                            
                            String sql1 = "SELECT * FROM CONTACTS";
                            Statement stat1 = con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_UPDATABLE);
                            ResultSet rs1 = stat1.executeQuery(sql1);
                        
                            rs1.moveToInsertRow();
                            rs1.updateString("USERNAME",Username);
                            rs1.updateString("NAME", name);
                            rs1.updateString("PHONENO", contactnumber);
                            rs1.updateString("EMAIL", email);
                            rs1.updateString("USER_PHONENO", M_No);
                            rs1.updateInt("PORT", port);
                            rs1.insertRow(); 
            
                            stat1.close();
                            rs1.close();

                            String sql3 = "SELECT * FROM COUNTER";
                            Statement stat3 = con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_UPDATABLE);
                            ResultSet rs3 = stat3.executeQuery(sql3);
                    
                            rs3.absolute(1);
                            rs3.updateInt("CONTACT_PORT", port);
                            rs3.updateRow(); 
                    
                            stat3.close();
                            rs3.close();
                            
                            JOptionPane.showMessageDialog(null , "Contact No added Successfully!");
                        
                            NameTxtBox.setText("");
                            ContactNumberTxtBox.setText("");
                            EmailTxtBox.setText("");
                        }   
                    }                         
                }
            }
            catch (SQLException se)
            {
                JOptionPane.showMessageDialog(null , "This Contact-Number is not on SoftChat!" /*se.getMessage()*/);
            }     
        }
    }//GEN-LAST:event_AddContact_ButtonActionPerformed

    private void DeleteContacts_LabelMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_DeleteContacts_LabelMouseClicked
        // TODO add your handling code here:
        
        DeleteContacts dc = new DeleteContacts(Username);
        dc.setVisible(true);
        dc.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        dc.setSize(455,500);
        this.setVisible(false);
    }//GEN-LAST:event_DeleteContacts_LabelMouseClicked

    private void DeleteContacts_LabelMouseEntered(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_DeleteContacts_LabelMouseEntered
        // TODO add your handling code here:

        DeleteContacts_Label.setForeground(Color.blue);
    }//GEN-LAST:event_DeleteContacts_LabelMouseEntered

    private void DeleteContacts_LabelMouseExited(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_DeleteContacts_LabelMouseExited
        // TODO add your handling code here:

        DeleteContacts_Label.setBackground(Color.gray);
        DeleteContacts_Label.setForeground(Color.black);
    }//GEN-LAST:event_DeleteContacts_LabelMouseExited

    private void EditContacts_LabelMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_EditContacts_LabelMouseClicked
        // TODO add your handling code here:

        DeleteContacts dc = new DeleteContacts(Username);
        dc.setVisible(true);
        dc.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        dc.setSize(455,500);
        this.setVisible(false);
    }//GEN-LAST:event_EditContacts_LabelMouseClicked

    private void EditContacts_LabelMouseEntered(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_EditContacts_LabelMouseEntered
        // TODO add your handling code here:

        EditContacts_Label.setForeground(Color.blue);
    }//GEN-LAST:event_EditContacts_LabelMouseEntered

    private void EditContacts_LabelMouseExited(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_EditContacts_LabelMouseExited
        // TODO add your handling code here:

        EditContacts_Label.setBackground(Color.gray);
        EditContacts_Label.setForeground(Color.black);
    }//GEN-LAST:event_EditContacts_LabelMouseExited

    private void NewGroup_LabelMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_NewGroup_LabelMouseClicked
        // TODO add your handling code here:

        NewGroup ng = new NewGroup(Username);
        ng.setVisible(true);
        ng.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setVisible(false);
    }//GEN-LAST:event_NewGroup_LabelMouseClicked

    private void NewGroup_LabelMouseEntered(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_NewGroup_LabelMouseEntered
        // TODO add your handling code here:

        NewGroup_Label.setForeground(Color.blue);
    }//GEN-LAST:event_NewGroup_LabelMouseEntered

    private void NewGroup_LabelMouseExited(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_NewGroup_LabelMouseExited
        // TODO add your handling code here:

        NewGroup_Label.setBackground(Color.gray);
        NewGroup_Label.setForeground(Color.black);
    }//GEN-LAST:event_NewGroup_LabelMouseExited

    private void MyGroups_LabelMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_MyGroups_LabelMouseClicked
        // TODO add your handling code here:
        
        MyGroups mg = new MyGroups(Username);
        mg.setVisible(true);
        mg.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setVisible(false);
    }//GEN-LAST:event_MyGroups_LabelMouseClicked

    private void MyGroups_LabelMouseEntered(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_MyGroups_LabelMouseEntered
        // TODO add your handling code here:

        MyGroups_Label.setForeground(Color.blue);
    }//GEN-LAST:event_MyGroups_LabelMouseEntered

    private void MyGroups_LabelMouseExited(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_MyGroups_LabelMouseExited
        // TODO add your handling code here:

        MyGroups_Label.setBackground(Color.gray);
        MyGroups_Label.setForeground(Color.black);
    }//GEN-LAST:event_MyGroups_LabelMouseExited

    private void AddContacts_LabelMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_AddContacts_LabelMouseClicked
        // TODO add your handling code here:
        
        AddContacts ac = new AddContacts(Username);
        ac.setVisible(true);
        ac.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setVisible(false);
    }//GEN-LAST:event_AddContacts_LabelMouseClicked

    private void Groups_LabelMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_Groups_LabelMouseClicked
        // TODO add your handling code here:
        
        Groups g = new Groups(Username);
        g.setVisible(true);
        g.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setVisible(false);
    }//GEN-LAST:event_Groups_LabelMouseClicked

    private void Groups_LabelMouseEntered(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_Groups_LabelMouseEntered
        // TODO add your handling code here:

        Groups_Label.setForeground(Color.blue);
    }//GEN-LAST:event_Groups_LabelMouseEntered

    private void Groups_LabelMouseExited(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_Groups_LabelMouseExited
        // TODO add your handling code here:

        Groups_Label.setBackground(Color.gray);
        Groups_Label.setForeground(Color.black);
    }//GEN-LAST:event_Groups_LabelMouseExited

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
            java.util.logging.Logger.getLogger(AddContacts.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(AddContacts.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(AddContacts.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(AddContacts.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        //java.awt.EventQueue.invokeLater(new Runnable() {
          //  public void run() {
            //    new AddContacts().setVisible(true);
            //}
        //});
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton AddContact_Button;
    private javax.swing.JLabel AddContacts_Label;
    private javax.swing.JLabel Chat_Label;
    private javax.swing.JTextField ContactNumberTxtBox;
    private javax.swing.JLabel Contacts_Label;
    private javax.swing.JLabel DeleteContacts_Label;
    private javax.swing.JLabel EditContacts_Label;
    private javax.swing.JTextField EmailTxtBox;
    private javax.swing.JLabel Groups_Label;
    private javax.swing.JLabel LogOut_Label;
    private javax.swing.JLabel MyGroups_Label;
    private javax.swing.JTextField NameTxtBox;
    private javax.swing.JLabel NewGroup_Label;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel6;
    private javax.swing.JLabel jLabel7;
    private javax.swing.JLabel jLabel8;
    // End of variables declaration//GEN-END:variables
}
