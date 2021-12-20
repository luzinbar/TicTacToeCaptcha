<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TicTacToeCaptcha._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <center>        
        <br />
        <asp:Image ID="Image1" runat="server" ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRw6DghY6yE2ukHqcOhM4-1sAAoAvvopdHZbw&usqp=CAU" />
        <br />
        <asp:Label ID="notArobot" Text="ARE YOU A ROBOT?" BorderStyle="solid" BorderColor="white" runat="Server" />
        <br />
        <asp:Label ID="Label1" Text="Prove us wrong!" BorderStyle="solid" BorderColor="white" runat="Server" />
        <br />
        <asp:Label ID="capcha_lbl" Text="Please play the TicTacToe game vs the computer:" BorderStyle="solid" BorderColor="white" runat="Server" />
        <br />
        <br />
        
        <table>
          <tr>
            <th><asp:ImageButton id="imagebutton1" runat="server" AlternateText="1" ImageUrl="https://cdn-icons.flaticon.com/png/512/4478/premium/4478286.png?token=exp=1639936414~hmac=eca681cb103f80936545173b39021702" Width = 50 Height = 50 OnClick="button_click_general"/></th>
            <th><asp:ImageButton id="imagebutton2" runat="server" AlternateText="2" ImageUrl="https://cdn-icons.flaticon.com/png/512/4478/premium/4478286.png?token=exp=1639936414~hmac=eca681cb103f80936545173b39021702" Width = 50 Height = 50 OnClick="button_click_general"/></th>
            <th><asp:ImageButton id="imagebutton3" runat="server" AlternateText="3" ImageUrl="https://cdn-icons.flaticon.com/png/512/4478/premium/4478286.png?token=exp=1639936414~hmac=eca681cb103f80936545173b39021702" Width = 50 Height = 50 OnClick="button_click_general"/></th>
          </tr>
          <tr>
            <th><asp:ImageButton id="imagebutton4" runat="server" AlternateText="4" ImageUrl="https://cdn-icons.flaticon.com/png/512/4478/premium/4478286.png?token=exp=1639936414~hmac=eca681cb103f80936545173b39021702" Width = 50 Height = 50 OnClick="button_click_general"/></th>
            <th><asp:ImageButton id="imagebutton5" runat="server" AlternateText="5" ImageUrl="https://cdn-icons.flaticon.com/png/512/4478/premium/4478286.png?token=exp=1639936414~hmac=eca681cb103f80936545173b39021702" Width = 50 Height = 50 OnClick="button_click_general"/></th>
            <th><asp:ImageButton id="imagebutton6" runat="server" AlternateText="6" ImageUrl="https://cdn-icons.flaticon.com/png/512/4478/premium/4478286.png?token=exp=1639936414~hmac=eca681cb103f80936545173b39021702" Width = 50 Height = 50 OnClick="button_click_general"/></th>
          </tr>
          <tr>
            <th><asp:ImageButton id="imagebutton7" runat="server" AlternateText="7" ImageUrl="https://cdn-icons.flaticon.com/png/512/4478/premium/4478286.png?token=exp=1639936414~hmac=eca681cb103f80936545173b39021702" Width = 50 Height = 50 OnClick="button_click_general"/></th>
            <th><asp:ImageButton id="imagebutton8" runat="server" AlternateText="8" ImageUrl="https://cdn-icons.flaticon.com/png/512/4478/premium/4478286.png?token=exp=1639936414~hmac=eca681cb103f80936545173b39021702" Width = 50 Height = 50 OnClick="button_click_general"/></th>
            <th><asp:ImageButton id="imagebutton9" runat="server" AlternateText="9" ImageUrl="https://cdn-icons.flaticon.com/png/512/4478/premium/4478286.png?token=exp=1639936414~hmac=eca681cb103f80936545173b39021702" Width = 50 Height = 50 OnClick="button_click_general"/></th>
          </tr>
        </table>

        <br />
        <asp:Label ID="illegal_input" Text="" BorderStyle="solid" BorderColor="white" runat="Server" />
        <br />
        <asp:Button runat="server" ID="btn_login" Text="" OnClick="button_click_login" />
        <br />
        <br />
        <br />
        <br />
        <br />
</asp:Content>


