   M S B A M L   `   `   `  ����G  Cfood_express, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:food_expressfood_express  5   	       food_express.EditDish   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:food_express     5   	     � Title$1  +Изменить товар в заказе��5   	   $	��250��6)   $	��310��66   $��Gabriola)�6B   .��5	      �� .+�5
   
   �� -   5         ��Name$ LabelDishName��5
      $��18(�6'   $��36��65    �� Left$ 10��6A   
 �� Top$ 10��6R   $	��292��6b   �� 5   
   -   5        $ LabelDishCost��5      $��18(�6'   $��36��65   $ 10��6A   $ 43��6R   $	��292��6b   �� 5   
   $��Количество: ��6   $��18(�6'   $��36��65   $ 10��6A   $ 76��6R   �� 5   
   -   5         ��Name$ TextBoxDishCount��5      $��18(�6,   $��36��6:   $	 100��6F   $ 76��6X   $	��162��6h   6t   �� 5   
   -   5         ��Name$ ButtonCountIncrement��5   n   $��Segoe UI)�6   $��12(�6'   $��20��65   $��18��6@   $	 262��6L   $ 76��6^   .��6�   +6�   �� 5   
   -   5        $ ButtonCountDecrement��5   n   $��Segoe UI)�6   $��12(�6'   $��20��65   $��18��6@   $	 262��6L   $ 94��6^   .��6�   -6�   �� 5   
   -   5        $ DialogResultCancel��5   Y   $��14(�6   $��36��6   $ 84��6+   $	 168��6<   $	��124��6M   .��6�   Отменить6�   �� 5   
   -   5        $ 
RemoveDish��5   p   $��14(�6   $��36��6   $ 19��6+   $	 127��6<   $	��124��6M   ���	#FFFF3333.��6�   " Удалить из заказа6�   �� 5   
   -   5        $ DialogResultConfirm��5   q   $��14(�6   $��36��6   $	 148��6+   $	 127��6=   $	��124��6N   ���	#FFFFBB0E.��6�   Подтвердить6�   5      5      