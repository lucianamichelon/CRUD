<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="CRUD.Web.Employees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $().ready(function () {
            $("[id$='txtBirthDate']").mask("99/99/9999");
        });

    </script>
    <div class="col-md-12">

        <asp:GridView ID="gdvEmployees" runat="server" OnDataBinding="DataBindEmployees" OnRowEditing="gdvEmployees_RowEditing" OnRowDeleting="gdvEmployees_RowDeleting" OnRowCancelingEdit="gdvEmployees_RowCancelingEdit" OnRowUpdating="gdvEmployees_RowUpdating" AllowPaging="true" OnPageIndexChanging="gdvEmployees_PageIndexChanging" PageSize="5">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>First Name</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblfirstName" runat="server" Text='<%= Eval("first_name") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtfirstName" runat="server" Text='<%= Eval("first_name") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>Last Name</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblLastName" runat="server" Text='<%= Eval("last_name") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtLastName" runat="server" Text='<%= Eval("last_name") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>Gender</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblgender" runat="server" Text='<%= Eval("gender") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:RadioButtonList runat="server" ID="rdbGender">
                            <asp:ListItem Text="M" Value="M"></asp:ListItem>
                            <asp:ListItem Text="F" Value="F"></asp:ListItem>
                        </asp:RadioButtonList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>Birth Date</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblBirthDate" runat="server" Text='<%= Eval("birth_date") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBirthDate" runat="server" Text='<%= Eval("birth_date") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>Hire Date</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblHireDate" runat="server" Text='<%= Eval("hire_date") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowDeleteButton="true" />
                <asp:CommandField ButtonType="Button" ShowInsertButton="true" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="col-md-12">
        <h2>Add Employees</h2>
        <p>
            <span class="form label">
                <asp:Label runat="server" ID="lblFirstName">First Name</asp:Label>
            </span>
            <span class="form textBox">
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rfvFirstName" ControlToValidate="txtFirstName" ErrorMessage="First Name is required" ValidationGroup="employees"> *</asp:RequiredFieldValidator>
            </span>
        </p>
        <p>
            <span class="form label">
                <asp:Label runat="server" ID="lblLastName">Last Name</asp:Label>
            </span>
            <span class="form textBox">
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rfvLastName" ControlToValidate="txtLastName" ErrorMessage="Last name is required" ValidationGroup="employees"> *</asp:RequiredFieldValidator>
            </span>
        </p>
        <p>
            <span class="form label">
                <asp:Label runat="server" ID="lblbirthDate">Birth Date</asp:Label>
            </span>
            <span class="form textBox">
                <asp:TextBox ID="txtBirthDate" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rfvBirthDate" ControlToValidate="txtBirthDate" ErrorMessage="Birth date is required" ValidationGroup="employees"> *</asp:RequiredFieldValidator>
            </span>
        </p>
        <p>
            <span class="form label">
                <asp:Label runat="server" ID="lblGender">Gender</asp:Label>
            </span>
            <span class="form textBox">
                <asp:RadioButtonList runat="server" ID="rdbGender">
                    <asp:ListItem Text="M" Value="M"></asp:ListItem>
                    <asp:ListItem Text="F" Value="F"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator runat="server" ID="rfvGender" ControlToValidate="rdbGender" ErrorMessage="Gender is required" ValidationGroup="employees"> *</asp:RequiredFieldValidator>
            </span>
        </p>
        <p>
            <asp:Button runat="server" ID="btnAdd" CausesValidation="true" OnClick="btnAdd_Click" Text="Add" />
        </p>
    </div>
</asp:Content>
