   M S B A M L   `   `   `  ����B  >AirPort, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:AirPort.ViewsAirPort.Views  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5	      &     AirPort.Views.StationsStatusView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:AirPort.Views     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5	        � DataContext  5
      ��    Locator �� Source# [   �� Path$ status�.  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *GetStatusComand+5      .��5      � $��	0,0,0,199q�6   .+�5   
   &   System.Windows.Controls.DataGrid  $	��251��6A      AutoGenerateColumns .  ��6   �� *
Stations+ �� Mode$ TwoWay=�	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 
Station ID��6C   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	stationID+6C     5      $
 Station Number��6H    6%   �� *stationNnumber+6H     5      $
 
AirPlaneID��6D    6%   �� *
airplaneID+6D     5      $
 Station Status��6O    6%   �� *_CurrentStationStatus+   ElementStyle 5      �� 5       �� 
TargetType" ��6     �� Triggers 5      P� 5   "    P� Property � �� P� Value$
 Free��6:   . �5   &   ��  �� Property � �� �� Value
 ����6C   5   #   P� 5   "    � ��$
 Busy��6:   . �5    &   ��  � ��
 �  ��6C   5!   #   5$      5'      5)      5,      5-      