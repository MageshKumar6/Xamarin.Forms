﻿using System;
using Xamarin.Forms.Xaml;
namespace  Xamarin.Forms.Previewer
{
	public class XamlParser
	{
		public static string XamlSimpleString = @"<ContentPage xmlns=""http://xamarin.com/schemas/2014/forms""
             xmlns:x=""http://schemas.microsoft.com/winfx/2009/xaml""
             x:Class=""XamlSamples.GridDemoPage""
             Title=""Grid Demo Page"">
	<Label Text=""Hello, XAML!""
       VerticalOptions=""Center""
       FontAttributes=""Bold""
       FontSize=""Large""
       TextColor=""Aqua"" />
</ContentPage>";

		public static string XamlComplexSampleString = @"<ContentPage xmlns=""http://xamarin.com/schemas/2014/forms""
             xmlns:x=""http://schemas.microsoft.com/winfx/2009/xaml""
             x:Class=""XamlSamples.GridDemoPage""
             Title=""Grid Demo Page"">

    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height=""Auto"" />
            <RowDefinition Height=""*"" />
            <RowDefinition Height=""100"" />
        </Grid.RowDefinitions>

        <Grid.ColumnDefinitions>
            <ColumnDefinition Width=""Auto"" />
            <ColumnDefinition Width=""*"" />
            <ColumnDefinition Width=""100"" />
        </Grid.ColumnDefinitions>

        <Label Text=""Autosized cell""
               Grid.Row=""0"" Grid.Column=""0""
               TextColor=""White""
               BackgroundColor=""Blue"" />

        <BoxView Color=""Silver""
                 HeightRequest=""0""
                 Grid.Row=""0"" Grid.Column=""1"" />

        <BoxView Color=""Teal""
                 Grid.Row=""1"" Grid.Column=""0"" />

        <Label Text=""Leftover space""
               Grid.Row=""1"" Grid.Column=""1""
               TextColor=""Purple""
               BackgroundColor=""Aqua""
               HorizontalTextAlignment=""Center""
               VerticalTextAlignment=""Center"" />

        <Label Text=""Span two rows (or more if you want)""
               Grid.Row=""0"" Grid.Column=""2"" Grid.RowSpan=""2""
               TextColor=""Yellow""
               BackgroundColor=""Blue""
               HorizontalTextAlignment=""Center""
               VerticalTextAlignment=""Center"" />

        <Label Text=""Span two columns""
               Grid.Row=""2"" Grid.Column=""0"" Grid.ColumnSpan=""2""
               TextColor=""Blue""
               BackgroundColor=""Yellow""
               HorizontalTextAlignment=""Center""
               VerticalTextAlignment=""Center"" />

        <Label Text=""Fixed 100x100""
               Grid.Row=""2"" Grid.Column=""2""
               TextColor=""Aqua""
               BackgroundColor=""Red""
               HorizontalTextAlignment=""Center""
               VerticalTextAlignment=""Center"" />

    </Grid>
</ContentPage>";
		public static Element ParseXaml(string xaml)
		{
			try
			{
				//TODO: Determine what type it is.
				return new ContentPage().LoadFromXaml(xaml);
			}
			catch(Exception e)
			{
				Console.WriteLine(e);
				//Report back xaml errors
				return null;
			}
		}
	}
}
