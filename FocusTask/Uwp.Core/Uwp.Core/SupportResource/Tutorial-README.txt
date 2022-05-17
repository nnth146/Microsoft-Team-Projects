Cách sử dụng:

<Page>
    <Page.Resources>
        <sr:ResButton
            x:Name="ResButton_TestButton"
            BackgroundPointerOver="LightCoral"
            BackgroundPressed="LightCoral" 
            xmlns:sr="using:Uwp.Controls.SR"/>
    </Page.Resources>
    <StackPanel>
        <Button Content="TestButton1" Resources="{Binding Source={StaticResource ResButton_TestButton}, Path=Resources}" />
        <Button Content="TestButton2" Resources="{Binding Source={StaticResource ResButton_TestButton}, Path=Resources}" />
    </StackPanel>
</Page>

Dễ dàng chèn các thuộc tính ẩn cho control!