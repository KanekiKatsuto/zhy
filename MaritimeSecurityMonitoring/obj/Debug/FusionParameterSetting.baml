   M S B A M L   `   `   `  ����U  QMaritimeSecurityMonitoring, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MaritimeSecurityMonitoringMaritimeSecurityMonitoring  5   	   7    1MaritimeSecurityMonitoring.FusionParameterSetting   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6m(clr-namespace:MaritimeSecurityMonitoring     5   	   -   5          � Title$  融合参数设置��5   	   $	��500��5   	   $	��500��6   $	��500��6$   $	��600��63   $	��600��6@   $	��600��6P    � WindowStyle$
 None=�6`    � AllowsTransparency . 
������  J� OpacityMask
 ����� � 
ResizeMode$ NoResize=�6�    � 	Resources 5         CornerLabel �� 
TargetType �� CornerRadius  CornerButton  TextBoxErrorTemp �� 
TargetType	 �� Triggers
 P� Property P� Value �� Property �� Value �� ElementName �� Path��%k  &	        &	 �     &	 l    �� 5   
   " ��6.   .R�5	      �� $��0q�6   $ 8,8,0,0��6)   ���	#FF4A79D8._�5
      �� #��z��6#   $
��Left=�6V   $��Center=�6q   $��10 0 0 0q�6�   5      5      �� 5   
   " ��6/   .R�5      �� $��0q�6   $ 5 5 5 5��6)   ���	#FF4A79D8._�5      �� #��z��6#   $��Center=�6V   $��Center=�6s   5      5      �� 5   
   " ��6)   	 5      P� 5      
 �@=�HasError . . �5      ��  �@=�ErrorTemplate 5      �� 5      .R�5   "   ]� ��. .+�5   &   �� $��Bottom=�60   
���  ��$��14(�6Y   $
��Bold"�6g   ��6y   �� $ 	MyAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�5   '   �� 5   &   
���  ��$��2q�6?   $��53��6S   ._�5   *   �� $��	MyAdorner��6D   5   '   5   #   5      5!      5"      5$      5%      .��5&      � 
������ .+�5'   
   �� 
�������$��0q�6%   $ 8,8,8,8��69   ��5(      �� 5)       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5*      �  � Color$ White��6#   5+      ._�5-      �  � RowDefinitions 5.      �� 5/      $��40 �6$   �� 50      $��* �6$   .+�52      �� #��[  6   $��20(�6@   
�������.��6a   融合参数设置6i   �� 53      -   5        $��22��53      $��22��6%   $��0 0 10 0q�60   $��Right=�6B   $��0q�6^   .��54      �� $��Image/Close_new.png��6   ��55      �� 56       �� Color$ 	#FF4A79D8��6*   58      � 59      $��1��6   $
��Auto��6$   $
��Auto��61    5:      �� 5;      $	��10* �6(   �� 5<      $	��11* �6(   �� 5=      $	��15* �6(   �� 5>      $	��11* �6(   �� 5?      $��9* �6(    � ColumnDefinitions 5A      �� 5B      $
��0.6* �6+   �� 5C      $��0 �6+   �� 5D      $��* �6+   .+�5F      � $��0��6   $��0��6)   $��3��69    5G      �� 5H      $��4* �6,   �� 5I      $��3* �6,   �� 5J      $��3* �6,    5L      �� 5M      $
��0.9* �6/   �� 5N      $��* �6/   �� 5O      $��* �6/   .+�5R      �� $��1��6!   $��0��6.   $��2��6>   $��3��6O   $��	25,0,25,0q�6c   ���#CCCCCC$��1q�6�   ._�5S      � $��0,10,0,0q�6(   .+�5T   "   �� $��	105 4 0 0q�6(   $��16(�6;   $��XYZ方向门限：0 ~��6I   �� 5U   "   -   5        $��xyzParameter��5U   *   #��[ 6>   $��0 4 0 0q�6h   $��50��6y   $��20��6�   $��16(�6�   $
��Left=�6�   $��Center=�6�   .��6�   ��5V   &   �� 5W   *   $ xyzParameter�62    �� Mode$ TwoWay=�6F    �� UpdateSourceTrigger$ PropertyChanged=�6T    �� NotifyOnValidationError .  �� ValidationRules 5X   .   =   7MaritimeSecurityMonitoring.NumberValidationRuleForFloat  5Y   2   6S   5[   +   .��5\   4   5]   #   �� 5^   "   $��5 4 0 0q�6(   $��16(�69   .��6G   米(m)6M   5_      5`      �� 5a      $��0��6    $��17(�60   
����������	#FF4A79D8$��30,25,165,10q�6h   $��Center=�6~   $
��Left=�6�   $��2��6�   $��2��6�   .��6�   XYZ坐标系参数6�   5b      � 5d      $��2��6   $��0��6)   $��3��69    5e      �� 5f      $
��0.8* �6,   �� 5g      $
��0.5* �6,   �� 5h      $��* �6,   �� 5i      $��* �6,   �� 5j      $��* �6,    5l      �� 5m      $
��0.9* �6/   �� 5n      $��* �6/   �� 5o      $��* �6/   .+�5r      �� $��1��6!   $��0��6.   $��4��6>   $��3��6O   $��	25,0,25,0q�6c   ���#CCCCCC$��1q�6�   ._�5s      � .+�5t   "   � $��0 10 0 0q�6,   .+�5u   &   �� $��	105,0,0,0q�6,   $��16(�6?   .��6M   告警的门限：6U   	� 5v   &   -   5        $��prompt��5v   t   $��10 0 0 0q�62   $��Center=�6D   $��16(�6f   .��6�   提示6�   	� 5w   &   -   5        $
��warn��5w   t   $��20 0 0 0q�62   $��Center=�6D   $��16(�6f   .��6�   告警6�   5x   #   � 5y   "   $��0 3 0 0q�6,   .+�5z   &   �� $��	105,0,0,0q�6,   $��16(�6?   .��6M   雷达消失时间：6V   �� 5{   &   -   5        $��radarDisappearTime��5{   .   #��[ 6H   $��50��6r   $��20��6}   $��16(�6�   $
��Left=�6�   $��Center=�6�   .��6�   ��5|   *   �� 5}   .   $ 	radarMiss�66   $ TwoWay=�6G   $ PropertyChanged=�6U    .  5~   2   <   6MaritimeSecurityMonitoring.NumberValidationRuleForLong  5   6   6V   5�   /   .��5�   8   5�   '   �� 5�   &   $��5 0 0 0q�6,   $��16(�6=   .��6K   秒(S)6Q   5�   #   � 5�   "   $��0 3 0 0q�6,   .+�5�   &   �� $��	105,0,0,0q�6,   $��16(�6?   .��6M   AIS 消失时间：6X   �� 5�   &   -   5        $��AISDisappearTime��5�   .   #��[ 6F   $��2 0 0 0q�6p   $��50��6�   $��20��6�   $��15(�6�   $
��Left=�6�   $��Center=�6�   .��6�   ��5�   *   �� 5�   .   $ AISMiss�66   $ TwoWay=�6E   $ PropertyChanged=�6S    .  5�   2     5�   6   6V   5�   /   .��5�   8   5�   '   �� 5�   &   $��5 0 0 0q�6,   $��16(�6=   .��6K   秒(S)6Q   5�   #   5�      5�      �� 5�      $��0��6!   $��0��6.   $��2��6>   $��30��6P   $��17(�6\   $��
30,14,40,1q�6j   
����������	#FF4A79D8$��Center=�6�   $
��Left=�6�   .��6�   门限参数6�   5�      � 5�      $��1��6   $��0��6)   $��3��69    5�      �� 5�      $
��0.8* �6,   �� 5�      $
��0.5* �6,   �� 5�      $��* �6,   �� 5�      $��* �6,    5�      �� 5�      $
��0.9* �6/   �� 5�      $��* �6/   �� 5�      $��* �6/   .+�5�      �� $��1��6!   $��0��6.   $��3��6>   $��3��6O   $��	25,0,25,0q�6c   ���#CCCCCC$��1q�6�   ._�5�      � .+�5�   "   � $��0 10 0 0q�6,   .+�5�   &   �� $��	105 0 0 0q�6,   $��16(�6?   .��6M   距离门距： 0 ~6X   �� 5�   &   -   5        $��abrDistance��5�   .   #��[ 6A   $��50��6k   $��20��6v   $��16(�6�   $
��Left=�6�   $��Center=�6�   .��6�   ��5�   *   �� 5�   .   $ abrDistance�66   $ TwoWay=�6I   $ PropertyChanged=�6W    .  5�   2     5�   6   6W   5�   /   .��5�   8   5�   '   �� 5�   &   $��5 0 0 0q�6,   $��16(�6=   .��6K   米(m)6Q   5�   #   � 5�   "   .+�5�   &   �� $��	105 0 0 0q�6,   $��16(�6?   .��6M   角度门限： 0 ~6X   �� 5�   &   -	   5        $��abrAngle��5�   .   #��[ 6>   $��50��6h   $��20��6s   $��16(�6   $
��Left=�6�   $��Center=�6�   .��6�   ��5�   *   �� 5�   .   $ abrAngle�66   $ TwoWay=�6F   $ PropertyChanged=�6T    .  5�   2     5�   6   6W   5�   /   .��5�   8   5�   '   �� 5�   &   $��5 0 0 0q�6,   $��16(�6=   .��6K   	度(°)6Q   5�   #   5�      5�      �� 5�      $��0��6!   $��0��6.   $��2��6>   $��30��6P   $��17(�6\   $��30,14,168,0q�6j   
����������	#FF4A79D8$��Center=�6�   $
��Left=�6�   $��2��6�   .��6  abr坐标系参数6  5�      � 5�      $��3��6   $��0��6)   $��3��69    5�      �� 5�      $
��0.8* �6,   �� 5�      $
��0.5* �6,   �� 5�      $��* �6,   �� 5�      $��* �6,    5�      �� 5�      $
��0.9* �6/   �� 5�      $��* �6/   �� 5�      $��* �6/   .+�5�      �� $��1��6!   $��0��6.   $��3��6>   $��3��6O   $��	25,0,25,0q�6c   ���#CCCCCC$��1q�6�   ._�5�      � .+�5�   "   � $��0 10 0 0q�6,   .+�5�   &   �� $��	105,0,0,0q�6,   $��16(�6?   .��6M   起始值 IM：6V   �� 5�   &   -
   5        $��IMParameter��5�   .   #��[ 6A   $��50��6k   $��20��6v   $��16(�6�   $
��Left=�6�   $��Center=�6�   .��6�   ��5�   *   �� 5�   .   $ IM�66   $ TwoWay=�6@   $ PropertyChanged=�6N    .  5�   2     5�   6   6V   5�   /   .��5�   8   5�   '   �� 5�   &   $��10,0,0,0q�6,   $��16(�6>   .��6L   起始值 IN：6U   �� 5�   &   -   5        $��INParameter��5�   .   #��[ 6A   $��50��6k   $��20��6v   $��16(�6�   $
��Left=�6�   $��Center=�6�   .��6�   ��5�   *   �� 5�   .   $ IN�66   $ TwoWay=�6@   $ PropertyChanged=�6N    .  5�   2     5�   6   6V   5�   /   .��5�   8   5�   '   5�   #   � 5�   "   .+�5�   &   �� $��	105,0,0,0q�6,   $��16(�6?   .��6M   估计算法：6T   	� 5�   &   -   5        $��RadioB3��5�   e   $��Center=�62   $��5 0 0 0q�6T   $��16(�6t   .��6�   最优6�   	� 5�   &   -   5        $��RadioB4��5�   f   $��Center=�62   $��20 0 0 0q�6T   $��16(�6u   .��6�   加权6�   	� 5�   &   -   5        $��RadioB5��5�   f   $��Center=�62   $��20 0 0 0q�6T   $��16(�6u   .��6�   SF6�   5�   #   5�      5�      �� 5�      $��0��6!   $��0��6.   $��2��6>   $��30��6P   $��17(�6\   $��
30,14,25,0q�6j   
����������	#FF4A79D8$��Center=�6�   $
��Left=�6�    J� RenderTransformOrigin$ 0.545,0.967&�6�   .��6  规则及算法6  5�      �� 5�      -   5        #��[ 5�      $��4��6F   $��0��6S   $��Center=�6c   $��30��6~   
�������$��16(�6�   $��136,30,264,30q�6�   $��3��6�   .��6�   确定6�   �� 5�      -   5        #��[ 5�      $��4��6F   $��2��6S   $��Center=�6c   $��30��6~   
�������$��16(�6�   $��84,30,136,30q�6�   .��6�   取消6�   5�      5�      5�      5�      5�      