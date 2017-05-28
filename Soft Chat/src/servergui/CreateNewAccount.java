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
 * @author Saad Afzaal
 */
public class CreateNewAccount extends javax.swing.JFrame {

    /**
     * Creates new form CreateNewAccount
     */
    public CreateNewAccount() {
        initComponents();
        
        InternalFrame.getContentPane().setBackground(Color.white);
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
        InternalFrame = new javax.swing.JInternalFrame();
        jLabel2 = new javax.swing.JLabel();
        jLabel3 = new javax.swing.JLabel();
        UsernameTxtBox = new javax.swing.JTextField();
        EmailTxtBox = new javax.swing.JTextField();
        jLabel4 = new javax.swing.JLabel();
        PasswordTxtBox = new javax.swing.JPasswordField();
        jLabel5 = new javax.swing.JLabel();
        ConfirmPasswordTxtBox = new javax.swing.JPasswordField();
        jLabel6 = new javax.swing.JLabel();
        PhoneNoTxtBox = new javax.swing.JTextField();
        Register_Button = new javax.swing.JButton();
        GoBack_Button = new javax.swing.JButton();
        jLabel7 = new javax.swing.JLabel();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setTitle("CreateNewAccount");

        jLabel1.setFont(new java.awt.Font("Tahoma", 1, 18)); // NOI18N
        jLabel1.setText("Create New Account");

        InternalFrame.setVisible(true);

        jLabel2.setFont(new java.awt.Font("Tahoma", 0, 15)); // NOI18N
        jLabel2.setText("Username  :");

        jLabel3.setFont(new java.awt.Font("Tahoma", 0, 15)); // NOI18N
        jLabel3.setText("Email  :");

        UsernameTxtBox.setFont(new java.awt.Font("Tahoma", 0, 15)); // NOI18N

        EmailTxtBox.setFont(new java.awt.Font("Tahoma", 0, 15)); // NOI18N

        jLabel4.setFont(new java.awt.Font("Tahoma", 0, 15)); // NOI18N
        jLabel4.setText(" Password  :");

        PasswordTxtBox.setFont(new java.awt.Font("Tahoma", 0, 15)); // NOI18N

        jLabel5.setFont(new java.awt.Font("Tahoma", 0, 15)); // NOI18N
        jLabel5.setText("Confirm Password  :");

        ConfirmPasswordTxtBox.setFont(new java.awt.Font("Tahoma", 0, 15)); // NOI18N
        ConfirmPasswordTxtBox.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                ConfirmPasswordTxtBoxActionPerformed(evt);
            }
        });

        jLabel6.setFont(new java.awt.Font("Tahoma", 0, 15)); // NOI18N
        jLabel6.setText("Phone No  :");

        PhoneNoTxtBox.setFont(new java.awt.Font("Tahoma", 0, 15)); // NOI18N

        Register_Button.setFont(new java.awt.Font("Tahoma", 0, 17)); // NOI18N
        Register_Button.setText("Register");
        Register_Button.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                Register_ButtonActionPerformed(evt);
            }
        });

        GoBack_Button.setFont(new java.awt.Font("Tahoma", 0, 17)); // NOI18N
        GoBack_Button.setText("GoBack");
        GoBack_Button.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                GoBack_ButtonActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout InternalFrameLayout = new javax.swing.GroupLayout(InternalFrame.getContentPane());
        InternalFrame.getContentPane().setLayout(InternalFrameLayout);
        InternalFrameLayout.setHorizontalGroup(
            InternalFrameLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(InternalFrameLayout.createSequentialGroup()
                .addGap(63, 63, 63)
                .addComponent(jLabel6)
                .addGroup(InternalFrameLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(InternalFrameLayout.createSequentialGroup()
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addComponent(Register_Button, javax.swing.GroupLayout.PREFERRED_SIZE, 105, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .addComponent(GoBack_Button, javax.swing.GroupLayout.PREFERRED_SIZE, 105, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(InternalFrameLayout.createSequentialGroup()
                        .addGap(12, 12, 12)
                        .addComponent(PhoneNoTxtBox)))
                .addContainerGap())
            .addGroup(InternalFrameLayout.createSequentialGroup()
                .addGroup(InternalFrameLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(InternalFrameLayout.createSequentialGroup()
                        .addGroup(InternalFrameLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(InternalFrameLayout.createSequentialGroup()
                                .addGap(60, 60, 60)
                                .addComponent(jLabel4))
                            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, InternalFrameLayout.createSequentialGroup()
                                .addContainerGap()
                                .addComponent(jLabel5)))
                        .addGap(12, 12, 12)
                        .addGroup(InternalFrameLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                            .addComponent(PasswordTxtBox, javax.swing.GroupLayout.DEFAULT_SIZE, 233, Short.MAX_VALUE)
                            .addComponent(ConfirmPasswordTxtBox)))
                    .addGroup(InternalFrameLayout.createSequentialGroup()
                        .addGap(60, 60, 60)
                        .addGroup(InternalFrameLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                            .addComponent(jLabel3)
                            .addComponent(jLabel2))
                        .addGap(12, 12, 12)
                        .addGroup(InternalFrameLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                            .addComponent(UsernameTxtBox)
                            .addComponent(EmailTxtBox, javax.swing.GroupLayout.PREFERRED_SIZE, 232, javax.swing.GroupLayout.PREFERRED_SIZE))))
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );
        InternalFrameLayout.setVerticalGroup(
            InternalFrameLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(InternalFrameLayout.createSequentialGroup()
                .addGap(26, 26, 26)
                .addGroup(InternalFrameLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel2)
                    .addComponent(UsernameTxtBox, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(18, 18, 18)
                .addGroup(InternalFrameLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel3)
                    .addComponent(EmailTxtBox, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(18, 18, 18)
                .addGroup(InternalFrameLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(PasswordTxtBox, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jLabel4))
                .addGap(18, 18, 18)
                .addGroup(InternalFrameLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(ConfirmPasswordTxtBox, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jLabel5))
                .addGap(18, 18, 18)
                .addGroup(InternalFrameLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(PhoneNoTxtBox, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jLabel6))
                .addGap(18, 18, 18)
                .addGroup(InternalFrameLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(Register_Button)
                    .addComponent(GoBack_Button))
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );

        jLabel7.setIcon(new javax.swing.ImageIcon(getClass().getResource("/servergui/Create_an_account_missing_piece.jpg"))); // NOI18N
        jLabel7.setText("jLabel7");

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(jLabel1)
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(jLabel7, javax.swing.GroupLayout.PREFERRED_SIZE, 348, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addComponent(InternalFrame, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)))
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(jLabel1)
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                    .addComponent(InternalFrame)
                    .addComponent(jLabel7, javax.swing.GroupLayout.DEFAULT_SIZE, 358, Short.MAX_VALUE))
                .addContainerGap(22, Short.MAX_VALUE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void GoBack_ButtonActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_GoBack_ButtonActionPerformed
        // TODO add your handling code here:
        
        ChatSoft cs = new ChatSoft();
        cs.setVisible(true);
        cs.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setVisible(false);
    }//GEN-LAST:event_GoBack_ButtonActionPerformed

    private void Register_ButtonActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_Register_ButtonActionPerformed
        // TODO add your handling code here:
        
        String username = UsernameTxtBox.getText();
        String email = EmailTxtBox.getText();
        String password = PasswordTxtBox.getText();
        String confirm_password = ConfirmPasswordTxtBox.getText();
        String phoneno = PhoneNoTxtBox.getText();
        
        if(username.equals("") || email.equals("") || password.equals("") || confirm_password.equals("") || phoneno.equals(""))
        {
            JOptionPane.showMessageDialog(null , "All fields must be filled");
        }
        else
        {
            if(password.equals(confirm_password))
            {
                try
                {  
                    long phone_no = Long.parseLong(phoneno);
                    int lenght = PhoneNoTxtBox.getText().length();                
                    
                    if(lenght == 11)
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
                            int count = rs.getInt("COUNT");
                            String sc_type = rs.getString("SC_TYPE");
                            
                            String SC_Type;
                            
                            if(sc_type.equals("S"))
                            {
                                SC_Type = "C";
                            }
                            else
                            {
                                SC_Type = "S";
                            }
                            
                            count++;
                            
                            String id_text = "IFN000";
                            String count_text = Integer.toString(count);
                            String id = id_text + count_text;
                            
                            String sql1 = "SELECT * FROM ACCOUNTS";
                            Statement stat1 = con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_UPDATABLE);
                            ResultSet rs1 = stat1.executeQuery(sql1);
            
                            rs1.moveToInsertRow();
                            rs1.updateString("ID",id);
                            rs1.updateString("PHONENO", phoneno);
                            rs1.updateString("USERNAME", username);
                            rs1.updateString("PASSWORD", password);
                            rs1.updateString("EMAIL", email);
                            rs1.updateString("TYPE", SC_Type);
                            rs1.insertRow(); 
                            
                            JOptionPane.showMessageDialog(null , "You are Registered Successfully!");
                            
                            String sql2 = "SELECT * FROM COUNTER";
                            Statement stat2 = con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_UPDATABLE);
                            ResultSet rs2 = stat2.executeQuery(sql2);
                            
                            rs2.absolute(1);
                            rs2.updateInt("COUNT", count);
                            rs2.updateString("SC_TYPE", SC_Type);
                            rs2.updateRow();   
                            
                            String sql3 = "SELECT * FROM SESSION";
                            Statement stat3 = con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_UPDATABLE);
                            ResultSet rs3 = stat3.executeQuery(sql3);
            
                            rs3.moveToInsertRow();
                            rs3.updateString("USERNAME",username);
                            rs3.updateBoolean("SESSION_ID", true);
                            rs3.insertRow(); 
                            
                            String sql4 = "SELECT * FROM LOGGINCHECK";
                            Statement stat4 = con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_UPDATABLE);
                            ResultSet rs4 = stat4.executeQuery(sql4);
            
                            rs4.moveToInsertRow();
                            rs4.updateString("USERNAME",username);
                            rs4.updateString("ISLOGGIN", "Yes");
                            rs4.insertRow();
                            
                            stat4.close();
                            rs4.close();
                            
                            MainPage mp = new MainPage(username);
                            mp.setVisible(true);
                            mp.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
                            this.setVisible(false);
                        }
                        catch (SQLException se)
                        {
                            JOptionPane.showMessageDialog(null , "On Your PhoneNo has already created account or Your Username is already in use!"/*se.getMessage()*/);
                            CreateNewAccount cna = new CreateNewAccount();
                            cna.setVisible(true);
                            cna.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
                            this.setVisible(false);
                        }        
                    }
                    else
                    {
                        JOptionPane.showMessageDialog(null , "Invalid PhoneNo must include 11 digits!");
                    }
                }
                catch(Exception ex)
                {
                    JOptionPane.showMessageDialog(null , "PhoneNo must be in digits");
                }      
            }
            else
            {
                    JOptionPane.showMessageDialog(null , "Password and ConfirmPassword must be match!");
            }     
        }
    }//GEN-LAST:event_Register_ButtonActionPerformed

    private void ConfirmPasswordTxtBoxActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_ConfirmPasswordTxtBoxActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_ConfirmPasswordTxtBoxActionPerformed

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
            java.util.logging.Logger.getLogger(CreateNewAccount.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(CreateNewAccount.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(CreateNewAccount.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(CreateNewAccount.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new CreateNewAccount().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JPasswordField ConfirmPasswordTxtBox;
    private javax.swing.JTextField EmailTxtBox;
    private javax.swing.JButton GoBack_Button;
    private javax.swing.JInternalFrame InternalFrame;
    private javax.swing.JPasswordField PasswordTxtBox;
    private javax.swing.JTextField PhoneNoTxtBox;
    private javax.swing.JButton Register_Button;
    private javax.swing.JTextField UsernameTxtBox;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JLabel jLabel3;
    private javax.swing.JLabel jLabel4;
    private javax.swing.JLabel jLabel5;
    private javax.swing.JLabel jLabel6;
    private javax.swing.JLabel jLabel7;
    // End of variables declaration//GEN-END:variables
}