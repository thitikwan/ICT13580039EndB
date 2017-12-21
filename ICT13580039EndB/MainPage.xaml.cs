﻿using System;
using System.Collections.Generic;
using ICT13580039EndB.Models;
using Xamarin.Forms;

namespace ICT13580039EndB
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            newButton.Clicked += NewButton_Clicked;
        }

        void NewButton_Clicked(object sender, EventArgs e)
        {
			Navigation.PushModalAsync(new ProductNewPage());
        }
		protected override void OnAppearing()
		{
			LoadData();
		}
		void LoadData()
		{
            CarListView.ItemsSource = App.DBHelper.GetProduct();
		}
		private void Edit_Clicked(object sender, EventArgs e)
		{
			var button = sender as MenuItem;
            var product = button.CommandParameter as Product;
			Navigation.PushModalAsync(new ProductNewPage(product));
		}

		async void Delete_Clicked(object sender, EventArgs e)
		{
			var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการลบใช่หรือไม่", "ใช่", "ไม่ใช่");
			if (isOk)
			{
				var button = sender as MenuItem;
                var product = button.CommandParameter as Product;
                App.DBHelper.DeleteProduct(product);

				await DisplayAlert("ลบสำเร็จ", "ลบข้อมูลสินค้าเรียบร้อย", "ตกลง");
				LoadData();
			}
		}
    }
}
