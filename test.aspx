<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="testimonial">
        <div class="container">
            <div class="row">          
                <asp:Repeater ID="rpttestimonials" runat="server">
                    <ItemTemplate>
                        <asp:Literal ID="littesid" runat="server" Visible="false" Text='<%#Eval("tesid")%>'></asp:Literal>

                        <div class="col-md-6" data-aos="fade-up">
                            <div class="img-box">
                                <a href="/Uploads/TestimonialImage/<%#Eval("Uploadphoto") %>" class="wow fadeIn animated" data-wow-delay=".1s" data-bs-toggle="modal" data-bs-target="#video-modal<%#Eval("testimonialid")%>">
                                    <figure>
                                        <img class="w-100" src="/Uploads/TestimonialImage/<%#Eval("Uploadphoto") %>" alt="testimonial-img">
                                    </figure>

                                    <div class="detail">
                                        <figure>
                                            <img src="/images/play-icon-white.svg" alt="play-icon">
                                        </figure>
                                        <h5><%#Eval("testimonialname")%></h5>
                                        <span><%#Eval("desg")%></span>
                                    </div>
                                </a>
                            </div>
                        </div>
                        <div class="col-md-6" data-aos="fade-up">
                            <div class="text-box">
                                <p>
                                    <%#Server.HtmlDecode(Eval("testimonialdesc").ToString()).Replace("<p>","").Replace("</p>","")%>
                                </p>

                                <h5><%#Eval("testimonialname")%></h5>
                                <span><%#Eval("desg")%></span>
                            </div>

                        </div>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <div class="col-md-6" data-aos="fade-up">
                            <div class="text-box">
                                <p>
                                    <%#Server.HtmlDecode(Eval("testimonialdesc").ToString()).Replace("<p>","").Replace("</p>","")%>
                                </p>

                                <h5><%#Eval("testimonialname")%></h5>
                                <span><%#Eval("desg")%></span>
                            </div>

                        </div>
                        <div class="col-md-6" data-aos="fade-up">
                            <div class="img-box">
                                <a href="/Uploads/TestimonialImage/<%#Eval("Uploadphoto") %>" class="wow fadeIn animated" data-wow-delay=".1s" data-bs-toggle="modal" data-bs-target="#video-modal<%#Eval("testimonialid")%>">
                                    <figure>
                                        <img class="w-100" src="/Uploads/TestimonialImage/<%#Eval("Uploadphoto") %>" alt="testimonial-img">
                                    </figure>
                                    <div class="detail">
                                        <figure>
                                            <img src="/images/play-icon-white.svg" alt="play-icon">
                                        </figure>
                                        <h5><%#Eval("testimonialname")%></h5>
                                        <span><%#Eval("desg")%></span>
                                    </div>
                                </a>
                            </div>
                        </div>
                    </AlternatingItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>

    <%--<div class="modal fade video-modal" id="video-modal1" tabindex="-1"  aria-hidden="true">
	  <div class="modal-dialog">
	    <div class="modal-content">
	      <div class="modal-body">
	      	<button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close">
	      		<img src="images/close.svg" alt="icon close">
	      	</button>
	        <iframe style="display: none;"></iframe>
	         <iframe width="1264" height="711" style="width:100%; height: 50rem;" src="https://www.youtube.com/embed/WLSIDYtp-Vw" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
	      </div>
	      <div class="modal-footer">
	        <p>Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem.</p>
	      </div>
	    </div>
	  </div>
	</div>	--%>



    <asp:Repeater ID="rptvedio" runat="server">
      <ItemTemplate>
          <asp:Literal ID="littesid" runat="server" Visible="false" Text='<%#Eval("tesid")%>'></asp:Literal>
          <div class="model fade video-modal" id="video-model1<%#Eval("testimonialid")%>>" tabindex="-1" aria-hidden="true">
           <div class="model-dialog">
             <div class="model-content">
              <div class="model-body">
              <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close">
	      		<img src="images/close.svg" alt="icon close">
	           </button>
                <iframe style="display: none;"></iframe>
                 <iframe width="1264" height="711" style="width: 100%; height: 50rem;" src="/uploads/<%#Eval("uploadvedio")%>" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
                
              
             </div>
               <div class="modal-footer">
                  <p><%#Eval("testimonialname")%></p>
                     </div>
                     </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>
