<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValidationControls.aspx.cs" Inherits="MyWebSite.ServerControls.ValidationControls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/jscript">
      function EmpIDClientValidate(ctrl, args) {
        // modulus by 5,
        args.isValid = (args.Value % 5 == 0);
      }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <!-- what will be introduced here is validation:
        BaseValidator
          RequiredFieldValidator
          RangeValidator
      -->
      <asp:Label runat="server" Text="Description" />
      <asp:Label runat="server" Text="Value" />
      <br /><br />
    
      <asp:Label runat="server" Text="Name" />
      <asp:TextBox runat="server" ID="Name">
      </asp:TextBox>

      <!-- what is the use of the * -->
      <asp:RequiredFieldValidator runat="server" ControlToValidate="Name" ErrorMessage="Name is required" Display="Dynamic" >*
      </asp:RequiredFieldValidator>

      <br /><br />

      <!-- CustomValidator -->
      <asp:Label ID="Label1" runat="server" Text="ID (multiple of 5)" />
      <asp:TextBox runat="server" ID="EmpID" />
      <!-- Custom validate have
          ClientValidationFunction
          OnServerValidate 
      -->
      <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="EmpID" ClientValidationFunction="EmpIDClientValidate" OnServerValidate="EmpIDServerValidate" ErrorMessage="ID must be a mutiple of 5" Display="Dynamic">*</asp:CustomValidator>
      <br /><br />

      <!-- RangeValidator -->
      <asp:Label ID="Label2" runat="server" Text="Day off (2008-08-05 - 2008-08-20)" />
      <asp:TextBox runat="server" ID="DayOff" />
      <!-- date format error  "08/05/2008" not supported, "2008-08-05" required -->
      <!-- <asp: RangeValidator ru nat="s erver" Display="Dynamic" ControlToValidate="DayOff" Type="Date" ErrorMessage="Day off is not within the valid interval"
      MinimumValue="08/05/2008" MaximumValue="08/06/2008">*</asp: RangeValidator> -->

      <asp:RangeValidator runat="server" Display="Dynamic" ControlToValidate="DayOff" Type="Date" ErrorMessage="Day off not within the valid interval"
      MinimumValue="2008-08-05" MaximumValue="2008-08-20">*</asp:RangeValidator>
      
      <br /><br />

      <!-- CompareValidator -->
      <asp:Label ID="Label3" runat="server" Text="Age (>= 18)" />
      <asp:TextBox runat="server" ID="Age"></asp:TextBox>
      <asp:CompareValidator runat="server" Display="Dynamic" ControlToValidate="Age" ValueToCompare="18" ErrorMessage="You must be at least 18 years old"
      Type="Integer" Operator="GreaterThanEqual">*</asp:CompareValidator>
      <br /><br />

      <!-- RegularExpression Validator -->
      <asp:Label ID="Label4" runat="server" Text="E-mail:" />
      <asp:TextBox runat="server" ID="email" />
      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"  ControlToValidate="Email" ValidationExpression=".*@.{2,}\..{2,}"
      ErrorMessage="E-mail is not in a valid format" Display="Dynamic">*</asp:RegularExpressionValidator>
      <br /><br />

      <asp:Label ID="Label5" runat="server" Text="Password" />
      <asp:TextBox runat="server" TextMode="Password" ID="Password" />
      <br /><br />

      <asp:Label ID="Label6" runat="server" Text="Re-enter password" />
      <asp:TextBox runat="server" TextMode="Password" ID="Password2" />
      <asp:CompareValidator runat="server" Display="Dynamic" ControlToValidate="Password2" ControlToCompare="Password" ErrorMessage="the Passwords does not match"
      Type="String">*</asp:CompareValidator>
      <br /><br />

      <!-- validate summary -->
      <asp:ValidationSummary runat="server" ID="Summary" ShowSummary="true" DisplayMode="BulletList" HeaderText="<b>Please review the following errors:</b>" />
      <br /><br />

      <asp:Button Text="Submit" runat="server" ID="cmdOK" />
    </div>
    </form>
</body>
</html>
