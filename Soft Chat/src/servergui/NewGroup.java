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
import java.awt.BorderLayout;
import java.awt.Font;
import javax.swing.*;
import javax.swing.border.Border;

/**
 *
 * @author Saad Afzaal
 */
public class NewGroup extends javax.swing.JFrame {

    private String Username;
    /**
     * Creates new form NewGroup
     */
    public NewGroup(String username) 
    {
        initComponents();
        
        Username = username;
        
        NewGroup_Label.setForeground(Color.blue);
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
        DeleteContacts_Label = new javax.swing.JLabel();
        EditContacts_Label = new javax.swing.JLabel();
        NewGroup_Label = new javax.swing.JLabel();
        MyGroups_Label = new javax.swing.JLabel();
        Chat_Label = new javax.swing.JLabel();
        Contacts_Label = new javax.swing.JLabel();
        jLabel2 = new javax.swing.JLabel();
        SubjectTxtBox = new javax.swing.JTextField();
        Next_Button = new javax.swing.JButton();
        jLabel3 = new javax.swing.JLabel();
        NameTxtBox = new javax.swing.JTextField();
        Groups_Label = new javax.swing.JLabel();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setTitle("NewGroup");

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
            public void mouseExited(java.awt.event.MouseEvent evt) {
                AddContacts_LabelMouseExited(evt);
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

        jLabel2.setFont(new java.awt.Font("Tahoma", 0, 18)); // NOI18N
        jLabel2.setText("Type Group Subject Here  :");

        SubjectTxtBox.setFont(new java.awt.Font("Tahoma", 0, 18)); // NOI18N

        Next_Button.setFont(new java.awt.Font("Tahoma", 0, 18)); // NOI18N
        Next_Button.setText("NEXT");
        Next_Button.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                Next_ButtonActionPerformed(evt);
            }
        });

        jLabel3.setFont(new java.awt.Font("Tahoma", 0, 18)); // NOI18N
        jLabel3.setText("Group Name :");

        NameTxtBox.setFont(new java.awt.Font("Tahoma", 0, 15)); // NOI18N

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
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(jLabel1)
                            .addGroup(layout.createSequentialGroup()
                                .addGap(25, 25, 25)
                                .addComponent(Chat_Label)))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 60, Short.MAX_VALUE)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                                .addComponent(DeleteContacts_Label)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                                .addComponent(AddContacts_Label)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                                .addComponent(LogOut_Label)
                                .addContainerGap())
                            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                                    .addComponent(Contacts_Label)
                                    .addGroup(layout.createSequentialGroup()
                                        .addComponent(Groups_Label)
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                                        .addComponent(MyGroups_Label)
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                                        .addComponent(NewGroup_Label)
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                                        .addComponent(EditContacts_Label)))
                                .addGap(34, 34, 34))))
                    .addGroup(layout.createSequentialGroup()
                        .addGap(25, 25, 25)
                        .addComponent(jLabel3)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addComponent(NameTxtBox)
                        .addGap(34, 34, 34))))
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                    .addComponent(Next_Button, javax.swing.GroupLayout.PREFERRED_SIZE, 217, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(SubjectTxtBox, javax.swing.GroupLayout.PREFERRED_SIZE, 217, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jLabel2))
                .addGap(86, 86, 86))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
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
                            .addComponent(Groups_Label)))
                    .addComponent(jLabel1))
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGap(21, 21, 21)
                        .addComponent(Chat_Label))
                    .addGroup(layout.createSequentialGroup()
                        .addGap(18, 18, 18)
                        .addComponent(Contacts_Label)))
                .addGap(37, 37, 37)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel3)
                    .addComponent(NameTxtBox, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 32, Short.MAX_VALUE)
                .addComponent(jLabel2)
                .addGap(28, 28, 28)
                .addComponent(SubjectTxtBox, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(30, 30, 30)
                .addComponent(Next_Button)
                .addGap(40, 40, 40))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private String Get_No(String Mname)
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
            String M_No = rs.getString("PHONENO");
            
            stat.close();
            rs.close();
            
            return M_No;
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

    private void AddContacts_LabelMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_AddContacts_LabelMouseClicked
        // TODO add your handling code here:

        AddContacts ac = new AddContacts(Username);
        ac.setVisible(true);
        ac.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setVisible(false);
    }//GEN-LAST:event_AddContacts_LabelMouseClicked

    private void AddContacts_LabelMouseEntered(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_AddContacts_LabelMouseEntered
        // TODO add your handling code here:

        AddContacts_Label.setBackground(Color.blue);
        AddContacts_Label.setForeground(Color.blue);
    }//GEN-LAST:event_AddContacts_LabelMouseEntered

    private void AddContacts_LabelMouseExited(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_AddContacts_LabelMouseExited
        // TODO add your handling code here:

        AddContacts_Label.setBackground(Color.gray);
        AddContacts_Label.setForeground(Color.black);
    }//GEN-LAST:event_AddContacts_LabelMouseExited

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

    private void Chat_LabelMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_Chat_LabelMouseClicked
        // TODO add your handling code here:

        Chat c = new Chat(Username);
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

    private void Next_ButtonActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_Next_ButtonActionPerformed
        // TODO add your handling code here:
        
        String Subject = SubjectTxtBox.getText();
        String Name = NameTxtBox.getText();
        
        if(Subject.equals("") || Name.equals(""))
        {
            JOptionPane.showMessageDialog(null , "Group Name and Group Subject must be NonEmpty!");
        }
        else
        {
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
                int count = rs.getInt("GROUP_COUNTER");
                int port = rs.getInt("PORT_NO");
                
                stat.close();
                rs.close();
                
                count++;
                port++;
                            
                String id_text = "GFN000";
                String count_text = Integer.toString(count);
                String id = id_text + count_text;
                
                String ContactNo = Get_No(Username);
                
                String sql1 = "SELECT * FROM GROUPS";
                Statement stat1 = con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_UPDATABLE);
                ResultSet rs1 = stat1.executeQuery(sql1);
            
                rs1.moveToInsertRow();
                rs1.updateString("GROUP_ID",id);
                rs1.updateString("GROUP_NAME", Name);
                rs1.updateString("GROUP_Subject", Subject);
                rs1.updateString("GROUP_Admin", Username);
                rs1.updateInt("PORT", port);
                rs1.updateString("IP_ADDRESS", "localhost");
                rs1.updateString("Admin_ContactNo", ContactNo);
                rs1.insertRow(); 
                
                stat1.close();
                rs1.close();
                
                if(ContactNo.equals(""))
                {
                    JOptionPane.showMessageDialog(null , "Connat Find ContactNo!");
                }
                else
                {
                    String sql3 = "SELECT * FROM GROUP_MEMBERS";
                    Statement stat3 = con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_UPDATABLE);
                    ResultSet rs3 = stat3.executeQuery(sql3);
            
                    rs3.moveToInsertRow();
                    rs3.updateString("GROUP_NAME",Name);
                    rs3.updateString("GROUP_Member_Name", Username);
                    rs3.updateString("GROUP_Member_CONTACTNO", ContactNo);
                    rs3.updateString("GROUP_Admin", Username);
                    rs3.insertRow(); 
                
                    stat3.close();
                    rs3.close();
                
                    JOptionPane.showMessageDialog(null , "Group Created Successfully!");
                }
                
                String sql2 = "SELECT * FROM COUNTER";
                Statement stat2 = con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_UPDATABLE);
                ResultSet rs2 = stat2.executeQuery(sql2);
                            
                rs2.absolute(1);
                rs2.updateInt("GROUP_COUNTER", count);
                rs2.updateInt("PORT_NO", port);
                rs2.updateRow();
 
                stat2.close();
                rs2.close();
                
                MyGroups mg = new MyGroups(Username);
                mg.setVisible(true);
                mg.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
                this.setVisible(false);
            }
            catch (SQLException se)
            {
                JOptionPane.showMessageDialog(null , "Group Name must be Unique!");
                NewGroup ng = new NewGroup(Username);
                ng.setVisible(true);
                ng.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
                this.setVisible(false);
            }    
        }
    }//GEN-LAST:event_Next_ButtonActionPerformed

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
            java.util.logging.Logger.getLogger(NewGroup.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(NewGroup.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(NewGroup.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(NewGroup.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        //java.awt.EventQueue.invokeLater(new Runnable() {
         //   public void run() {
          //      new NewGroup().setVisible(true);
          //  }
       // });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JLabel AddContacts_Label;
    private javax.swing.JLabel Chat_Label;
    private javax.swing.JLabel Contacts_Label;
    private javax.swing.JLabel DeleteContacts_Label;
    private javax.swing.JLabel EditContacts_Label;
    private javax.swing.JLabel Groups_Label;
    private javax.swing.JLabel LogOut_Label;
    private javax.swing.JLabel MyGroups_Label;
    private javax.swing.JTextField NameTxtBox;
    private javax.swing.JLabel NewGroup_Label;
    private javax.swing.JButton Next_Button;
    private javax.swing.JTextField SubjectTxtBox;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JLabel jLabel3;
    // End of variables declaration//GEN-END:variables
}