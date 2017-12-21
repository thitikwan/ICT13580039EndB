using System;
using System.Collections.Generic;
using ICT13580039EndB.Models;
using Xamarin.Forms;

namespace ICT13580039EndB
{
    public partial class ProductNewPage : ContentPage
    {
       
        private Product product;
        public ProductNewPage(Product product = null)
        {
            InitializeComponent();
            this.product = product;
            titleLabel.Text = product == null ? "เพิ่มข้อมูล" : "แก้ไขข้อมูลสินค้า ";

            categoryPicker.Items.Add("รถยนต์ตู้");
            categoryPicker.Items.Add("รถยนต์สปอต");
            brandPicker.Items.Add("TOYOTA");
            brandPicker.Items.Add("MASDA");
            cityPicker.Items.Add("กรุงเทพ");
			cityPicker.Items.Add("เพชรบุรี");
            colorPicker.Items.Add("แดง");
			colorPicker.Items.Add("ฟ้า");

            myStepper.ValueChanged += MyStepper_ValueChanged;
            mySlider.ValueChanged += MySlider_ValueChanged;

            saveButton.Clicked += SaveButton_Clicked;

            if(product!=null){
                categoryPicker.SelectedItem = product.Category;
                brandPicker.SelectedItem = product.Brand;
                classEntry.Text = product.Class;
                yearLabel.Text = product.Year;
                numberLabel.Text = product.Number.ToString();
                colorPicker.SelectedItem = product.Color;

                descriptionEditor.Text = product.Description;
                productPriceEntry.Text = product.ProductPrice.ToString();
                cityPicker.SelectedItem = product.ProductPrice;
                cellPhoneEntry.Text = product.TellPhone;
            }
        }

        async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("ยืนยัน","คุณต้องการบันทึกใช่หรือไม่","ใช่","ไม่");
            if(isOk){
                if(product == null){
                    product = new Product();
                    product.Category = categoryPicker.SelectedItem.ToString();
                    product.Brand = brandPicker.SelectedItem.ToString();
                    product.Class = classEntry.Text;
                    product.Year = yearLabel.Text;
                    product.Number = decimal.Parse(numberLabel.Text);
                    product.Color = colorPicker.SelectedItem.ToString();
                    product.Description = descriptionEditor.Text;
                    product.ProductPrice = decimal.Parse(productPriceEntry.Text);
                    product.City =cityPicker.SelectedItem.ToString();
                    product.TellPhone = cellPhoneEntry.Text;

                    var id = App.DBHelper.AddProduct(product);
                    await DisplayAlert("บันทึกสำเร็จ","รหัสสินค้าของท่าน"+id,"ตกลง");
                }
                else{
					product.Category = categoryPicker.SelectedItem.ToString();
					product.Brand = brandPicker.SelectedItem.ToString();
					product.Class = classEntry.Text;
					product.Year = yearLabel.Text;
					product.Number = decimal.Parse(numberLabel.Text);
					product.Color = colorPicker.SelectedItem.ToString();
					product.Description = descriptionEditor.Text;
					product.ProductPrice = decimal.Parse(productPriceEntry.Text);
					product.City = cityPicker.SelectedItem.ToString();
					product.TellPhone = cellPhoneEntry.Text;

                    var id = App.DBHelper.UpdateProduct(product);
					await DisplayAlert("บันทึกสำเร็จ", "แก้ไขข้อมูลเรียบร้อย" , "ตกลง");
				}
                await Navigation.PopModalAsync();
            }


        }
       


		void MyStepper_ValueChanged(object sender, ValueChangedEventArgs e)
		{
            int value = (int)e.NewValue;
            yearLabel.Text = value.ToString();
		}
        void MySlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
			int value = (int)e.NewValue;
            numberLabel.Text = value.ToString();
        }
    }
}
