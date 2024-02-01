<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true"
    CodeFile="brand.aspx.cs" Inherits="brand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="ccr_section gray-back-800 ">
        <div class="container-fluid p-0">
            <section class="portfolio brand_section">
			<div class="container">

				<%--<div class="filters-content mt-4">
					<div class="grid">
						<div class="all adhesives">
							<div class="item">
								<a href="/cpage.aspx?mpgid=36&amp;pgidtrail=36"><img class="img-fluid" src="images/brands/jivanjor.png" /> </a></div>
						</div>
						<div class="all epoxy-putty">
							<div class="item">
								<a href="/cpage.aspx?mpgid=46&amp;pgidtrail=46"><img class="img-fluid" src="images/brands/ultra.png" /> </a></div>
						</div>
						<div class="all speciality">
							<div class="item">
								<a href="/cpage.aspx?mpgid=45&amp;pgidtrail=45"><img class="img-fluid" src="images/brands/charmwood.png" /></a></div>
						</div>
						<div class="all epoxy-putty">
							<div class="item">
								<a href="/cpage.aspx?mpgid=43&amp;pgidtrail=43"><img class="img-fluid" src="images/brands/ram.png" /></a></div>
						</div>
						<div class="all adhesives">
							<div class="item">
								<a href="/cpage.aspx?mpgid=41&amp;pgidtrail=41"><img class="img-fluid" src="images/brands/vamicol.png" /></a></div>
						</div>
						<div class="all coating">
							<div class="item">
								<a href="/cpage.aspx?mpgid=38&amp;pgidtrail=38"><img class="img-fluid" src="images/brands/hero.png" /></a></div>
						</div>
						<div class="all coating">
							<div class="item">
								<a href="/cpage.aspx?mpgid=39&amp;pgidtrail=39"><img class="img-fluid" src="images/brands/polystic.png" /></a></div>
						</div>
						<div class="all speciality">
							<div class="item">
								<a href="/cpage.aspx?mpgid=40&amp;pgidtrail=40"><img class="img-fluid" src="images/brands/vamipol.png" /></a></div>
						</div>
						<div class="all epoxy-putty">
							<div class="item">
								<a href="/cpage.aspx?mpgid=42&amp;pgidtrail=42"><img class="img-fluid" src="images/brands/encord.png" /></a></div>
						</div>
						<div class="all coating">
							<div class="item">
								<a href="/cpage.aspx?mpgid=37&amp;pgidtrail=37"><img class="img-fluid" src="images/brands/termilok.png" /> </a></div>
						</div>
						<div class="all epoxy-putty">
							<div class="item">
								<a href="/cpage.aspx?mpgid=44&amp;pgidtrail=44"><img class="img-fluid" src="images/brands/jubigum.png" /></a></div>
						</div>
					</div>
				</div>--%>

                 <div class="filters-content mt-4">
                        <div class="grid">
                            <asp:Repeater ID="rptbrand" runat="server" OnItemDataBound="rptbrand_ItemDataBound">
                                <ItemTemplate>                                   
                                     <asp:Literal ID="litcatid" runat="server" Visible="false" Text='<%#Eval("catid")%>'></asp:Literal>
                                    <asp:Literal ID="litpcatid" runat="server" Visible="false" Text='<%#Eval("pcatid")%>'></asp:Literal>
                                    <div id="panel1" runat="server" class="all adhesives">
                                        <div class="item">
                                           <a id="ank" runat="server">
                                               <img src="/uploads/ProductsImage/<%#Eval("banner")%>" class="img-fluid">
                                           </a>
                                            
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                 
			</div>
		</section>
        </div>
    </div>
</asp:Content>
