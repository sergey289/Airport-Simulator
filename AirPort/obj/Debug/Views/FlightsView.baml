   M S B A M L   `   `   `  ����B  >AirPort, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:AirPort.ViewsAirPort.Views  5      5clr-namespace:AirPort.ViewModelAirPort.ViewModel  5      -clr-namespace:AirPort.ViewsAirPort.Views  5	      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5          AirPort.Views.FlightsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:AirPort.Views     5      .vmclr-namespace:AirPort.ViewModel     5      -viewsclr-namespace:AirPort.Views     5	      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5        � DataContext  5      ��    Locator �� Source# [   �� Path$ flight�.  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *GetFlightsComand+5      .��5      � $��
0,10,0,190q�6   .+�5   
   �� -   5         ��Name$ flight_view��5   @   $��10q�64   ��6   �� *	Flights+ �� View 5      �� 5      .P�5      �� $��	Flight ID��6%   	 �� Width$	 80��68   
 �� DisplayMemberBinding
 6C   �� *
flightID+�� 5      $��Flight Number��6%   $		 100��6<   
 6H   �� *flightNumber+�� 5      $��
AirPlaneID��6%   $		 100��69   
 6E   �� *
airPlaneID+�� 5      $��Destination��6%   $		 100��6:   
 6F   �� *destination+�� 5      $
��Time��6%   $		 100��63   
 6?   �� *time+�� 5      -   5        columHeader_Status��$��Status��5   A   $	 80��6Q   
 6\   �� *CurentStatus+5       5"      5#      5$      