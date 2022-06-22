<Page.Resources>
      <sr:ResButton x:Name="ResButton1" BackgroundPointerOver="LightBlue" />
</Page.Resources>

<Grid>
      <Button Content="Button1" Resources="{Binding Source={StaticResource ResButton1}, Path=Resources}" />
</Grid>
