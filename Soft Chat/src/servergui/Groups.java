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
import java.awt.GridLayout;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.util.ArrayList;
import java.util.List;
import javax.swing.*;
import javax.swing.border.BevelBorder;
import javax.swing.border.Border;
import org.jdesktop.swingx.autocomplete.AutoCompleteDecorator;


/**
 *
 * @author Saad Afzaal
 */
public class Groups extends javax.swing.JFrame {

    String Username;
    GridLayout G;
    JLabel MyLabel;
    
    /**
     * Creates new form Groups
     */
    public Groups(String username) 
    {
        initComponents();
        
        Username = username;
        
        Groups_Label.setForeground(Color.blue);
        
        FillGroupCombo();
        
        String ContactNo = Get_No(Username);
        
        if((ContactNo.equals("")))
        {
            JOptionPane.showMessageDialog(null , "Invalid ContactNo");
        }
        else
        {
            G = new GridLayout(0,1,5,5);
            jp.setLayout(G);
        
            ScrollPane.setBorder(new BevelBorder(BevelBorder.RAISED));
        
            Border border = BorderFactory.createLineBorder(Color.BLUE, 4);
        
            Border paddingBorder = BorderFactory.createEmptyBorder(10,10,10,10);
                    
            try
            {
                String url = "jdbc:derby://localhost:1527/MyDataBase";
                String uName = "Saad";
                String uPass= "03214061595";

                Connection con = DriverManager.getConnection(url , uName , uPass);
            
                String sql = "SELECT * FROM GROUP_MEMBERS where GROUP_MEMBER_CONTACTNO = '" + ContactNo + "'";
                Statement stat = con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_READ_ONLY);
                ResultSet rs = stat.executeQuery(sql);
                
                int count = 0;
                
                List<String> My_Stringslist = new ArrayList<String>();
                List<String> My_Title = new ArrayList<String>();
                List<String> My_Address = new ArrayList<String>();
                List<String> Group_Name = new ArrayList<String>();
                List<Integer> My_Port = new ArrayList<Integer>();
                
                while(rs.next())
                {
                    String groupname = rs.getString("GROUP_NAME");
                    
                    try
                    {  
                        String sql1 = "SELECT * FROM GROUPS where GROUP_NAME = '" + groupname + "'";
                        Statement stat1 = con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_READ_ONLY);
                        ResultSet rs1 = stat1.executeQuery(sql1);
                    
                        rs1.first();
                        String GroupName = rs1.getString("GROUP_NAME");   
                        String GroupSubject = rs1.getString("GROUP_SUBJECT");
                        String Address = rs1.getString("IP_ADDRESS");
                        int Port = rs1.getInt("PORT");
                    
                        String Title = GroupName + "  -----  " + GroupSubject;
                        
                        My_Title.add(Title);
                        My_Address.add(Address);
                        My_Port.add(Port);
                        Group_Name.add(GroupName);
                        
                        count++;
                        String C = Integer.toString(count);
                
                        String format = "%-23s%s";
                        
                        String text = String.format(format , GroupName , GroupSubject);
                        
                        String My_Strings = " " + C + "     " + text;
                        
                        My_Stringslist.add(My_Strings);
                    }
                    catch(SQLException se)
                    {
                        JOptionPane.showMessageDialog(null , se.getMessage());
                    }
                }
                
                stat.close();
                rs.close();
                
                JLabel My_Labels[] = new JLabel[My_Stringslist.size()];
                
                for(int i=0; i<My_Stringslist.size(); i++)
                {   
                    My_Labels[i] = new JLabel(My_Stringslist.get(i));
                
                    My_Labels[i].setFont(new Font("Serif" , Font.BOLD , 18));
                    My_Labels[i].setForeground(Color.BLACK);
                
                    My_Labels[i].setBorder(BorderFactory.createCompoundBorder(border,paddingBorder));
               
                    JLabel Label = My_Labels[i];
                
                    My_Labels[i].addMouseListener(
                    new MouseAdapter()
                    {  
                        public void mouseEntered(MouseEvent mEvt)
                        {
                            Label.setForeground(Color.blue);
                            Label.setBackground(Color.blue);
                        }
                    }
                    );
           
                    My_Labels[i].addMouseListener(
                    new MouseAdapter()
                    {
                        public void mouseExited(MouseEvent mEvt)
                        {
                            Label.setBackground(Color.gray);
                            Label.setForeground(Color.black);
                        }
                    }
                    ); 
                    
                    String title = My_Title.get(i);
                    String address = My_Address.get(i);
                    String group_name = Group_Name.get(i);
                    int port = My_Port.get(i);
                        
                    My_Labels[i].addMouseListener(
                    new MouseAdapter()
                    {
                        public void mouseClicked(MouseEvent mEvt)
                        {
                            ClientGroup cg = new ClientGroup(Username , title , address , port , group_name);
                            cg.setVisible(true);
                            cg.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
                        }
                    }
                    );
                }
                
                for(int i=0; i<My_Stringslist.size(); i++)
                {
                    jp.add(My_Labels[i]);
                }
                
                JLabel j1 = new JLabel("");
                jp.add(j1);
            }
            catch (SQLException se)
            {
                JOptionPane.showMessageDialog(null , "No Result Found!" /*se.getMessage()*/);
            }  
        }
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
        Groups_Label = new javax.swing.JLabel();
        Contacts_Label = new javax.swing.JLabel();
        Chat_Label = new javax.swing.JLabel();
        Group_ComboBox = new javax.swing.JComboBox<>();
        Display_Subject_Button = new javax.swing.JButton();
        SubjectTxtBox = new javax.swing.JTextField();
        Change_Subject_Button = new javax.swing.JButton();
        ScrollPane = new javax.swing.JScrollPane();
        jp = new javax.swing.JPanel();
        Leave_Group_Button = new javax.swing.JButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setTitle("Groups");

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

        Group_ComboBox.setFont(new java.awt.Font("Tahoma", 0, 16)); // NOI18N
        Group_ComboBox.setModel(new javax.swing.DefaultComboBoxModel<>(new String[] { "Select Group" }));

        Display_Subject_Button.setFont(new java.awt.Font("Tahoma", 0, 16)); // NOI18N
        Display_Subject_Button.setText("Display Subject");
        Display_Subject_Button.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                Display_Subject_ButtonActionPerformed(evt);
            }
        });

        SubjectTxtBox.setFont(new java.awt.Font("Tahoma", 0, 16)); // NOI18N

        Change_Subject_Button.setFont(new java.awt.Font("Tahoma", 0, 16)); // NOI18N
        Change_Subject_Button.setText("Change Subject");
        Change_Subject_Button.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                Change_Subject_ButtonActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout jpLayout = new javax.swing.GroupLayout(jp);
        jp.setLayout(jpLayout);
        jpLayout.setHorizontalGroup(
            jpLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 413, Short.MAX_VALUE)
        );
        jpLayout.setVerticalGroup(
            jpLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 211, Short.MAX_VALUE)
        );

        ScrollPane.setViewportView(jp);

        Leave_Group_Button.setFont(new java.awt.Font("Tahoma", 0, 16)); // NOI18N
        Leave_Group_Button.setText("Leave Group");
        Leave_Group_Button.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                Leave_Group_ButtonActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGap(46, 46, 46)
                        .addComponent(Chat_Label))
                    .addGroup(layout.createSequentialGroup()
                        .addContainerGap()
                        .addComponent(jLabel1)))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
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
                        .addGap(34, 34, 34))
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                        .addComponent(Contacts_Label)
                        .addGap(46, 46, 46))))
            .addGroup(layout.createSequentialGroup()
                .addGap(46, 46, 46)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                    .addComponent(ScrollPane, javax.swing.GroupLayout.PREFERRED_SIZE, 0, Short.MAX_VALUE)
                    .addComponent(SubjectTxtBox)
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                        .addComponent(Group_ComboBox, javax.swing.GroupLayout.PREFERRED_SIZE, 139, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(89, 89, 89)
                        .addComponent(Display_Subject_Button)))
                .addContainerGap(46, Short.MAX_VALUE))
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                    .addComponent(Change_Subject_Button, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addComponent(Leave_Group_Button, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                .addGap(158, 158, 158))
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
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(Contacts_Label)
                    .addComponent(Chat_Label))
                .addGap(33, 33, 33)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(Group_ComboBox, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(Display_Subject_Button))
                .addGap(30, 30, 30)
                .addComponent(SubjectTxtBox, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(27, 27, 27)
                .addComponent(Change_Subject_Button)
                .addGap(18, 18, 18)
                .addComponent(Leave_Group_Button)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 28, Short.MAX_VALUE)
                .addComponent(ScrollPane, javax.swing.GroupLayout.PREFERRED_SIZE, 213, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(22, 22, 22))
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
    
    private void FillGroupCombo()
    {
        try
        {
            String ContactNo = Get_No(Username);
            
            String url = "jdbc:derby://localhost:1527/MyDataBase";
            String uName = "Saad";
            String uPass= "03214061595";

            Connection con = DriverManager.getConnection(url , uName , uPass);
            
            String sql = "SELECT * FROM GROUP_MEMBERS where GROUP_MEMBER_CONTACTNO = '" + ContactNo + "' ORDER BY GROUP_NAME";
            Statement stat = con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_READ_ONLY);
            ResultSet rs = stat.executeQuery(sql);
            
            
            while (rs.next())
            {
                String name = rs.getString("GROUP_NAME");
                
                Group_ComboBox.addItem(name);
            }
            
            AutoCompleteDecorator.decorate(this.Group_ComboBox);
        }
        catch (SQLException se)
        {
            JOptionPane.showMessageDialog(null , se.getMessage());
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
        
    }//GEN-LAST:event_Groups_LabelMouseExited

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

    private void Display_Subject_ButtonActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_Display_Subject_ButtonActionPerformed
        // TODO add your handling code here:
        
        String Group_Name = (String)Group_ComboBox.getSelectedItem();
        
        try
        {
            String url = "jdbc:derby://localhost:1527/MyDataBase";
            String uName = "Saad";
            String uPass= "03214061595";

            Connection con = DriverManager.getConnection(url , uName , uPass);
            
            String sql = "SELECT * FROM GROUPS where GROUP_NAME = '" + Group_Name + "'";
            Statement stat = con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_READ_ONLY);
            ResultSet rs = stat.executeQuery(sql);
            
            rs.first();
            String Subject = rs.getString("GROUP_SUBJECT");
            
            SubjectTxtBox.setText(Subject);
        }
        catch (SQLException se)
        {
            JOptionPane.showMessageDialog(null , "Invalid Group"/*se.getMessage()*/);
            SubjectTxtBox.setText(null);
        }    
    }//GEN-LAST:event_Display_Subject_ButtonActionPerformed

    private void Change_Subject_ButtonActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_Change_Subject_ButtonActionPerformed
        // TODO add your handling code here:
        
        String Group_Name = (String)Group_ComboBox.getSelectedItem();
        
        String Subject = SubjectTxtBox.getText();
        
        if(Subject.equals(""))
        {
            JOptionPane.showMessageDialog(null , "Please Enter Some Subject!");
        }
        else
        {
            try
            {
                String url = "jdbc:derby://localhost:1527/MyDataBase";
                String uName = "Saad";
                String uPass= "03214061595";

                Connection con = DriverManager.getConnection(url , uName , uPass);
            
                String sql = "SELECT * FROM GROUPS where GROUP_NAME = '" + Group_Name + "'";
                Statement stat = con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_UPDATABLE);
                ResultSet rs = stat.executeQuery(sql);
            
                rs.absolute(1);
                rs.updateString("GROUP_SUBJECT", Subject);
                rs.updateRow();

                JOptionPane.showMessageDialog(null , "Group Subject Changed Successfully!");
                
                Groups g = new Groups(Username);
                g.setVisible(true);
                g.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
                this.setVisible(false);
            }
            catch (SQLException se)
            {
                JOptionPane.showMessageDialog(null , "Invalid Group"/*se.getMessage()*/);
            }
        }
    }//GEN-LAST:event_Change_Subject_ButtonActionPerformed
    
    private void Leave_Group_ButtonActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_Leave_Group_ButtonActionPerformed
        // TODO add your handling code here:
        
        String Group_Name = (String)Group_ComboBox.getSelectedItem();
        
        String ContactNo = Get_No(Username);
        
        try
        {
            String url = "jdbc:derby://localhost:1527/MyDataBase";
            String uName = "Saad";
            String uPass= "03214061595";

            Connection con = DriverManager.getConnection(url , uName , uPass);
            
            String sql = "SELECT * FROM GROUPS where GROUP_NAME = '" + Group_Name + "'";
            Statement stat = con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_READ_ONLY);
            ResultSet rs = stat.executeQuery(sql);
            
            rs.first();
            String admin = rs.getString("GROUP_ADMIN");
            
            try
            {
                String sql1 = "SELECT * FROM GROUPS where GROUP_NAME = '" + Group_Name + "' AND ADMIN_CONTACTNO = '" + ContactNo + "'";
                Statement stat1 = con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_READ_ONLY);
                ResultSet rs1 = stat1.executeQuery(sql1);
            
                rs1.first();
                String Admin = rs1.getString("GROUP_ADMIN");
                String AdminNo = rs1.getString("ADMIN_CONTACTNO");
                
                JOptionPane.showMessageDialog(null , "You are Admin of the Group cannot Leave the Group!");
            }
            catch (SQLException se)
            {
                try
                { 
                    String sql2 = "SELECT * FROM GROUP_MEMBERS where GROUP_NAME = '" + Group_Name +"' AND GROUP_MEMBER_CONTACTNO = '" + ContactNo + "'";
                    Statement stat2 = con.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_UPDATABLE);
                    ResultSet rs2 = stat2.executeQuery(sql2);
            
                    rs2.absolute(1);
                    rs2.deleteRow();
            
                    stat2.close();
                    rs2.close();
                    
                    JOptionPane.showMessageDialog(null , "You Leave the Group Successfully!");
                    
                    Groups g = new Groups(Username);
                    g.setVisible(true);
                    g.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
                    this.setVisible(false);
                }
                catch (SQLException ses)
                {
                    JOptionPane.showMessageDialog(null , ses.getMessage());
                }      
            }    
        }
        catch (SQLException se)
        {
            JOptionPane.showMessageDialog(null , "Invalid Group!"/*se.getMessage()*/);
        }    
    }//GEN-LAST:event_Leave_Group_ButtonActionPerformed

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
            java.util.logging.Logger.getLogger(Groups.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(Groups.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(Groups.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(Groups.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        //java.awt.EventQueue.invokeLater(new Runnable() {
          //  public void run() {
            //    new Groups().setVisible(true);
            //}
        //});
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JLabel AddContacts_Label;
    private javax.swing.JButton Change_Subject_Button;
    private javax.swing.JLabel Chat_Label;
    private javax.swing.JLabel Contacts_Label;
    private javax.swing.JLabel DeleteContacts_Label;
    private javax.swing.JButton Display_Subject_Button;
    private javax.swing.JLabel EditContacts_Label;
    private javax.swing.JComboBox<String> Group_ComboBox;
    private javax.swing.JLabel Groups_Label;
    private javax.swing.JButton Leave_Group_Button;
    private javax.swing.JLabel LogOut_Label;
    private javax.swing.JLabel MyGroups_Label;
    private javax.swing.JLabel NewGroup_Label;
    private javax.swing.JScrollPane ScrollPane;
    private javax.swing.JTextField SubjectTxtBox;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JPanel jp;
    // End of variables declaration//GEN-END:variables
}
