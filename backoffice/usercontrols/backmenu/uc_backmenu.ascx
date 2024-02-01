<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_backmenu.ascx.cs" Inherits="backoffice_usercontrols_backmenu_uc_backmenu" %>
<div class="glossymenu">
    <% if (string.IsNullOrEmpty(Request.QueryString["clid"]))
       { %>
    <asp:Repeater ID="repmain" runat="server" OnItemDataBound="repmain_ItemDataBound">
        <ItemTemplate>
            <asp:TextBox ID="moduleid" runat="server" Visible="false" Text='<%#Eval("moduleid")%>'></asp:TextBox>
            <a class="menuitem submenuheader" href="#">
                <%#Eval("modulename")%>
            </a>
            <div class="submenu">
                <ul>
                    <asp:Repeater ID="repinner" runat="server" OnItemCommand="repinner_ItemCommand">
                        <ItemTemplate>
                            <li>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandArgument='<%#Eval("Formname")%>'
                                    CommandName="show"><%#Eval("FormCaption")%></asp:LinkButton></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <%} %>
    <%else if (!string.IsNullOrEmpty(Request.QueryString["clid"]))
       { %>
      <%--<a class="menuitem submenuheader" href="#">Departments</a>
                   <div class="submenu">
                   <ul>
                   <li>
                   <a href="/backoffice/collage/collage-mapdepartments.aspx?clid=<%=Convert.ToString(Request.QueryString["clid"]) %>">
          Map  Departments</a>
                   </li>
                   </ul>
                   </div>--%>
    <a class="menuitem submenuheader" href="#">Home Banner</a>
    <div class="submenu">
        <ul>
        <li><a href="/backoffice/homebanner/addhomebannertype.aspx?clid=<%=Convert.ToString(Request.QueryString["clid"]) %>">
                Add/Edit Home Banner Type</a> </li>
            <li><a href="/backoffice/homebanner/addhomebanner.aspx?clid=<%=Convert.ToString(Request.QueryString["clid"]) %>">
                Add Banner</a> </li>
            <li><a href="/backoffice/homebanner/viewhomebanner.aspx?clid=<%=Convert.ToString(Request.QueryString["clid"]) %>">
                View Banner</a> </li>
        </ul>
    </div>
    <a class="menuitem submenuheader" href="#">Page Management</a>
    <div class="submenu">
        <ul>
            <li><a href="/backoffice/cms/addpages.aspx?clid=<%=Convert.ToString(Request.QueryString["clid"]) %>">
                Add Pages</a> </li>
            <li><a href="/backoffice/cms/viewpages.aspx?clid=<%=Convert.ToString(Request.QueryString["clid"]) %>">
                View Pages</a> </li>
        </ul>
    </div>

<%--     <a class="menuitem submenuheader" href="#">Course</a>
    <div class="submenu">
        <ul>
            <li><a href="/backoffice/collage/addcoursedetails.aspx?clid=<%=Convert.ToString(Request.QueryString["clid"]) %>">
                Add Course Details</a> </li>
            <li><a href="/backoffice/collage/viewcoursedetails.aspx?clid=<%=Convert.ToString(Request.QueryString["clid"]) %>">
                View Course Details</a> </li>
        </ul>
    </div>--%>
   
    <a class="menuitem submenuheader" href="#">Map Media</a>
    <div class="submenu">
        <ul>
            <li><a href="/backoffice/collage/collage-happenings.aspx?clid=<%=Convert.ToString(Request.QueryString["clid"]) %>">
                Map Media </a></li>
        </ul>
    </div>

    <a class="menuitem submenuheader" href="#">Map Research</a>
    <div class="submenu">
        <ul>
            <li><a href="/backoffice/collage/mapresearch.aspx?clid=<%=Convert.ToString(Request.QueryString["clid"]) %>">
                Map Research </a></li>
        </ul>
    </div>

    <a class="menuitem submenuheader" href="#">Map Faculty</a>
    <div class="submenu">
        <ul>
            <li><a href="/backoffice/collage/mapfaculty.aspx?clid=<%=Convert.ToString(Request.QueryString["clid"]) %>">
                Map Faculty </a></li>
        </ul>
    </div>
     <a class="menuitem submenuheader" href="#" >Map Testimonial</a>
    <div class="submenu" style="display:none;">
        <ul>
            <li><a href="/backoffice/collage/collage-testimonial.aspx?clid=<%=Convert.ToString(Request.QueryString["clid"]) %>">
                Map Testimonial </a></li>
        </ul>
    </div>
    
    <a class="menuitem submenuheader" href="#" > Map Gallery</a>
    <div class="submenu" style="display:none;">
        <ul>
            <li><a href="/backoffice/collage/map-photo-gallery.aspx?clid=<%=Convert.ToString(Request.QueryString["clid"]) %>">
                Map Gallery </a></li>
        </ul>
    </div>

     <%-- <a class="menuitem submenuheader" href="#" >Map Video Gallery</a>
    <div class="submenu" style="display:none;">
        <ul>
            <li><a href="/backoffice/collage/map-video-gallery.aspx?clid=<%=Convert.ToString(Request.QueryString["clid"]) %>">
                Map Video Gallery </a></li>
        </ul>
    </div>--%>
      <%-- <a class="menuitem submenuheader" href="#">Research Details</a>
    <div class="submenu" style="display:none;">
        <ul>
            <li><a href="/backoffice/collage/research-details.aspx?clid=<%=Convert.ToString(Request.QueryString["clid"]) %>">
                Research Details</a></li>
        </ul>
    </div>--%>





  
    
    <%} %>
</div>
