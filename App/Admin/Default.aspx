﻿<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<!DOCTYPE html>
<!--[if IE 8 ]><html class="no-js oldie ie8" lang="en"> <![endif]-->
<!--[if IE 9 ]><html class="no-js oldie ie9" lang="en"> <![endif]-->
<!--[if (gte IE 9)|!(IE)]><!--><html class="no-js" lang="en"> <!--<![endif]-->
<head>

   <!--- basic page needs
   ================================================== -->
   <meta charset="utf-8">
	<title>Shuseki - Productividad Remota</title>
	<meta name="description" content="">  
	<meta name="author" content="">

   <!-- mobile specific metas
   ================================================== -->
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">

 	<!-- CSS
   ================================================== -->
   <link rel="stylesheet" href="css/base.css">  
   <link rel="stylesheet" href="css/main.css">
   <link rel="stylesheet" href="css/vendor.css">     

   <!-- script
   ================================================== -->
	<script src="js/modernizr.js"></script>

   <!-- favicons
	================================================== -->
	<link rel="icon" type="image/ico" href="favicon.ico">

</head>

<body id="top">

	<!-- header 
   ================================================== -->
   <header>

   	<div class="row">

   		<div class="logo">
	         <a href="index.html">Shuseki</a>
	      </div>

	   	<nav id="main-nav-wrap">
				<ul class="main-navigation">
					<li class="current"><a class="smoothscroll"  href="#intro" title="">Home</a></li>
					<li><a class="smoothscroll"  href="#process" title="">Proceso</a></li>
					<li><a class="smoothscroll"  href="#features" title="">Caracteristicas</a></li>
					<li><a class="smoothscroll"  href="#pricing" title="">Precios</a></li>
					<li><a class="smoothscroll"  href="#faq" title="">FAQ</a></li>					                    
					<li class="highlight with-sep"><a href="/Login" title="">Ingresar</a></li>					
				</ul>
			</nav>

			<a class="menu-toggle" href="#"><span>Menu</span></a>
   		
   	</div>   	
   	
   </header> <!-- /header -->

	<!-- intro section
   ================================================== -->
   <section id="intro">

   	<div class="shadow-overlay"></div>

   	<div class="intro-content">
   		<div class="row">

   			<div class="col-twelve">

	   			<div class='video-link'>
	   				<a href="#video-popup"><img src="images/play-button.png" alt=""></a>
	   			</div>

	   			<h5>Bienvenido a Shuseki</h5>
	   			<h1>Controle la productividad de sus empleados remotos.</h1>

	   			<a class="button stroke smoothscroll" href="#process" title="">SABER MAS...</a>

	   		</div>  
   			
   		</div>   		 		
   	</div> 

   	<!-- Modal Popup
	   ========================================================= -->

      <div id="video-popup" class="popup-modal mfp-hide">

		   <div class="fluid-video-wrapper">
            <iframe src="http://player.vimeo.com/video/14592941?title=0&amp;byline=0&amp;portrait=0&amp;color=faec09" width="500" height="281" frameborder="0" webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe> 
         </div>		     

         <a class="close-popup">Close</a>         

	   </div> <!-- /video-popup -->  	 	

   </section> <!-- /intro -->


   <!-- Process Section
   ================================================== -->
   <section id="process">  

   	<div class="row section-intro">
   		<div class="col-twelve with-bottom-line">

   			<h5>Proceso</h5>
   			<h1>¿Comó funciona?</h1>

   			<p class="lead">Ofrecemos un servicio que permite auditar las horas laboradas y la productividad de sus empleados remotos mediante computador y teléfono móvil.</p>

   		</div>   		
   	</div>

   	<div class="row process-content">

   		<div class="left-side">

   			<div class="item" data-item="1">

   				<h5>Descargar Cliente</h5>

   				<p>Descarge el cliente disponible para su sistema operativo.</p>
   					
   			</div>

   			<div class="item" data-item="2">

	   			<h5>Instalar</h5>

	   			<p>Instale el cliente en el ordenador que desea monitorear.</p>
   					
   			</div>
   				
   		</div> <!-- /left-side -->
   		
   		<div class="right-side">
   				
   			<div class="item" data-item="3">

   				<h5>Vincular</h5>

   				<p>Vincule el cliente con un empleado.</p>
   					
   			</div>

   			<div class="item" data-item="4">

   				<h5>Administrar</h5>

   				<p>Loguee y use el dashboard de la plataforma para ver reportes y monitorear las actividades de sus empleados.</p>
   					
   			</div>

   		</div> <!-- /right-side -->  

   		<div class="image-part"></div>  			

   	</div> <!-- /process-content --> 

   </section> <!-- /process-->    


   <!-- features Section
   ================================================== -->
	<section id="features">

		<div class="row section-intro">
   		<div class="col-twelve with-bottom-line">

   			<h5>Características</h5>
   			<h1>Monitor de las actividades de los empleados remotos.</h1>

   			<p class="lead">Las características del sistema permiten monitorear las actividades de los empleados remotos y sus horas de entradas y salidas.</p>

   		</div>   		
   	</div>

   	<div class="row features-content">

   		<div class="features-list block-1-3 block-s-1-2 block-tab-full group">

	      	<div class="bgrid feature">	

	      		<span class="icon"><i class="icon-window"></i></span>            

	            <div class="service-content">	

	            	 <h3 class="h05">Fully Resposive</h3>

		            <p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit.
	         		</p>
	         		
	         	</div> 	         	 

				</div> <!-- /bgrid -->

				<div class="bgrid feature">	

					<span class="icon"><i class="icon-eye"></i></span>                          

	            <div class="service-content">	
	            	<h3 class="h05">Retina Ready</h3>  

		            <p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit.
	         		</p>

	         		
	            </div>	                          

			   </div> <!-- /bgrid -->

			   <div class="bgrid feature">

			   	<span class="icon"><i class="icon-paint-brush"></i></span>		            

	            <div class="service-content">
	            	<h3 class="h05">Stylish Design</h3>

		            <p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit.
	        			</p> 

	        			
	            </div> 	            	               

			   </div> <!-- /bgrid -->

				<div class="bgrid feature">

					<span class="icon"><i class="icon-file"></i></span>	              

	            <div class="service-content">
	            	<h3 class="h05">Clean Code</h3>

		            <p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit.
	         		</p> 

	         		
	            </div>                

				</div> <!-- /bgrid -->

			   <div class="bgrid feature">

			   	<span class="icon"><i class="icon-layers"></i></span>	            

	            <div class="service-content">	
	            	<h3 class="h05">Easy To Customize</h3>

		            <p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit.
	        			</p> 

	        			
	            </div>	               

			   </div> <!-- /bgrid -->

			   <div class="bgrid feature">

			   	<span class="icon"><i class="icon-gift"></i></span>	   	           

	            <div class="service-content">
	            	 <h3 class="h05">Free of Charge</h3>

		            <p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit.
	        			</p> 
	        			
	            </div>	               

			   </div> <!-- /bgrid -->

	      </div> <!-- features-list -->
   		
   	</div> <!-- features-content -->
		
	</section> <!-- /features -->
	

	<!-- pricing
   ================================================== -->

   <section id="pricing">

   	<div class="row section-intro">
   		<div class="col-twelve with-bottom-line">

   			<h5>Nuestros precios</h5>
   			<h1>Elija el plan que se ajuste a su negocio.</h1>

   			<p class="lead">Lorem ipsum Do commodo in proident enim in dolor cupidatat adipisicing dolore officia nisi aliqua incididunt Ut veniam lorem ipsum Consectetur ut in in eu do.</p>

   		</div>   		
   	</div>

   	<div class="row pricing-content">

         <div class="pricing-tables block-1-4 group" style="display: flex; justify-content:center">

            <div class="bgrid"> 

            	<div class="price-block">

            		<div class="top-part">

	            		<h3 class="plan-title">Startup</h3>
		               <p class="plan-price"><sup>$</sup>4.99</p>
		               <p class="price-month">Por mes</p>
		               <p class="price-meta">Cobrado anualmente.</p>

	            	</div>                

	               <div class="bottom-part">

	            		<ul class="features">
		                  <li><strong>50</strong> Conexiones maximas</li>
		                  <li>Monitor de entradas y salidas</li>		                  
                          <li>Monitor de productividad</li>		                  
                          <li>Dashboard y Reportes</li>		                  
		               </ul>

		               <a class="button large" href="">Seleccionar</a>

	            	</div>

            	</div>           	
                        
			   </div> <!-- /price-block -->

            <div class="bgrid">

            	<div class="price-block primary">

            		<div class="top-part" data-info="recommended">

	            		<h3 class="plan-title">PYME</h3>
		               <p class="plan-price"><sup>$</sup>9.99</p>
		               <p class="price-month">Por mes</p>
							<p class="price-meta">Cobrado anualmente.</p>

	            	</div>               

	               <div class="bottom-part">

	            		<ul class="features">
		                  <li><strong>200</strong> Conexiones maximas</li>
		                  <li>Monitor de entradas y salidas</li>		                  
                          <li>Monitor de productividad</li>		                  
                          <li>Dashboard y Reportes</li>
                          <li>Soporte para instalación del sistema</li>
		               </ul>

		               <a class="button large" href="">Seleccionar</a>

	            	</div>
            		
            	</div>            	                 

			  </div> <!-- /price-block --> 
             <div class="bgrid"> 

            	<div class="price-block">

            		<div class="top-part">

	            		<h3 class="plan-title">Premium</h3>
		               <p class="plan-price"><sup>$</sup>99.9</p>
		               <p class="price-month">Por mes</p>
		               <p class="price-meta">Cobrado anualmente.</p>

	            	</div>                

	               <div class="bottom-part">

	            		<ul class="features">
		                  <li><strong>Ilimitadas</strong> Conexiones</li>
		                  <li>Monitor de entradas y salidas</li>		                  
                          <li>Monitor de productividad</li>		                  
                          <li>Dashboard y Reportes</li>
                          <li>Soporte para instalación del sistema</li>
                          <li>Atención personalizada</li>
		               </ul>

		               <a class="button large" href="">Seleccionar</a>

	            	</div>

            	</div>           	
                        
			   </div> <!-- /price-block -->        

         </div> <!-- /pricing-tables --> 

      </div> <!-- /pricing-content --> 

   </section> <!-- /pricing --> 


   <!-- Testimonials Section
   ================================================== -->
   <section id="testimonials">

   	<div class="row">
   		<div class="col-twelve">
   			<h2 class="h01">Hear What Are Clients Say.</h2>
   		</div>   		
   	</div>   	

      <div class="row flex-container">
    
         <div id="testimonial-slider" class="flexslider">

            <ul class="slides">

               <li>
               	<div class="testimonial-author">
                    	<img src="images/avatars/avatar-1.jpg" alt="Author image">
                    	<div class="author-info">
                    		Steve Jobs
                    		<span class="position">CEO, Apple.</span>
                    	</div>
                  </div>

                  <p>
                  Your work is going to fill a large part of your life, and the only way to be truly satisfied is
                  to do what you believe is great work. And the only way to do great work is to love what you do.
                  If you haven't found it yet, keep looking. Don't settle. As with all matters of the heart, you'll know when you find it.  						
                  </p>                  
             	</li> <!-- /slide -->

               <li> 

               	<div class="testimonial-author">
                    	<img src="images/avatars/avatar-2.jpg" alt="Author image">
                    	<div class="author-info">
                    		John Doe
                    		<span>CEO, ABC Corp.</span>
                    	</div>
                  </div> 

                  <p>
                  This is Photoshop's version  of Lorem Ipsum. Proin gravida nibh vel velit auctor aliquet.
                  Aenean sollicitudin, lorem quis bibendum auctor, nisi elit consequat ipsum, nec sagittis sem
                  nibh id elit. Duis sed odio sit amet nibh vulputate cursus a sit amet mauris.    
                  </p>
                                         
               </li> <!-- /slide -->

            </ul> <!-- /slides -->

         </div> <!-- /testimonial-slider -->         
        
      </div> <!-- /flex-container -->

   </section> <!-- /testimonials -->


   <!-- faq
   ================================================== -->
   <section id="faq">

   	<div class="row section-intro">
   		<div class="col-twelve with-bottom-line">

   			<h5>Faq</h5>
   			<h1>Questions and Answers.</h1>

   			<p class="lead">Lorem ipsum Do commodo in proident enim in dolor cupidatat adipisicing dolore officia nisi aliqua incididunt Ut veniam lorem ipsum Consectetur ut in in eu do.</p>

   		</div>   		
   	</div>

   	<div class="row faq-content">

   		<div class="q-and-a block-1-2 block-tab-full group">

   			<div class="bgrid">

   				<h3>What are the security features?</h3>

   				<p>Lorem ipsum Id in magna ad culpa dolor eu aute non amet aute ea in consectetur in quis nostrud anim proident dolore in sed et mollit voluptate culpa irure consequat laborum ea sint in mollit adipisicing cupidatat.</p>

   			</div>

   			<div class="bgrid">

   				<h3>How can I update my user profile?</h3>

   				<p>Lorem ipsum Id in magna ad culpa dolor eu aute non amet aute ea in consectetur in quis nostrud anim proident dolore in sed et mollit voluptate culpa irure consequat laborum ea sint in mollit adipisicing cupidatat.</p>

   			</div>

   			<div class="bgrid">

   				<h3>What features are not included in the free version?</h3>

   				<p>Lorem ipsum Id in magna ad culpa dolor eu aute non amet aute ea in consectetur in quis nostrud anim proident dolore in sed et mollit voluptate culpa irure consequat laborum ea sint in mollit adipisicing cupidatat.</p>

   			</div>

   			<div class="bgrid">

   				<h3>Can I upgrade my account from Starter to Premium?</h3>

   				<p>Lorem ipsum Id in magna ad culpa dolor eu aute non amet aute ea in consectetur in quis nostrud anim proident dolore in sed et mollit voluptate culpa irure consequat laborum ea sint in mollit adipisicing cupidatat.</p>

   			</div>

   			<div class="bgrid">

   				<h3>Where can I found all my uploads?</h3>

   				<p>Lorem ipsum Id in magna ad culpa dolor eu aute non amet aute ea in consectetur in quis nostrud anim proident dolore in sed et mollit voluptate culpa irure consequat laborum ea sint in mollit adipisicing cupidatat.</p>

   			</div>

   			<div class="bgrid">

   				<h3>How long can I use the free trial version?</h3>

   				<p>Lorem ipsum Id in magna ad culpa dolor eu aute non amet aute ea in consectetur in quis nostrud anim proident dolore in sed et mollit voluptate culpa irure consequat laborum ea sint in mollit adipisicing cupidatat.</p>

   			</div>

   		</div> <!-- /q-and-a --> 
   		
   	</div> <!-- /faq-content --> 

   	<div class="row section-ads">

		   <div class="col-twelve">	

		     	<div class="ad-content">

		     		<h2 class="h01"><a href="http://www.dreamhost.com/r.cgi?287326|STYLESHOUT">Styleshout Recommends Dreamhost.</a></h2>

			      <p class="lead">
			      Looking for an awesome and reliable webhosting? Try <a href="http://www.dreamhost.com/r.cgi?287326|STYLESHOUT"><span>DreamHost</span></a>.
					Get <span>$50 off</span> when you sign up with the promocode <span>styleshout</span>. 
					<!-- Simply type	the promocode in the box labeled â€œPromo Codeâ€ when placing your order. -->					
					</p>

					<div class="action">
			         <a class="button large round" href="http://www.dreamhost.com/r.cgi?287326|STYLESHOUT">Sign Up Now</a>
		        	</div>

		     	</div>			      

			</div>

		</div> <!-- /section-ads --> 


   </section> <!-- /faq --> 

   <!-- cta
   ================================================== -->
   <section id="cta">

   	<div class="row cta-content">

   		<div class="col-twelve">

   			<h1 class="h01">Get started now. Try Lhander free for 30 days.</h1>

   			<p class="lead">Download the app now. Available on the:</p>

   			<ul class="stores">
   				<li class="app-store">
   					<a href="#" class="button round large" title="">
   						<i class="icon ion-social-apple"></i>App Store
   					</a>
   				</li>
   				<li class="play-store">
   					<a href="#" class="button round large" title="">
   						<i class="icon ion-social-android"></i>Play Store</a>
   					</li>
   				<li class="windows-store">
   					<a href="#" class="button round large" title="">
   						<i class="icon ion-social-windows"></i>Win Store</a>
   					</li>
   			</ul>

   		</div>

   	</div> <!-- /cta-content -->

   </section> <!-- /cta -->


   <!-- footer
   ================================================== -->
   <footer>

   	<div class="footer-main">

   		<div class="row">  

	      	<div class="col-four tab-full mob-full footer-info">            

	            <div class="footer-logo"></div>

	            <p>
		        	1600 Amphitheatre Parkway<br>
            	Mountain View, CA 94043 US<br>
		        	info@lhander.com &nbsp; +123-456-789
		        	</p>

		      </div> <!-- /footer-info -->

	      	<div class="col-two tab-1-3 mob-1-2 site-links">

	      		<h4>Site Links</h4>

	      		<ul>
	      			<li><a href="#">About Us</a></li>
						<li><a href="#">Blog</a></li>
						<li><a href="#">FAQ</a></li>
						<li><a href="#">Terms</a></li>
						<li><a href="#">Privacy Policy</a></li>
					</ul>

	      	</div> <!-- /site-links -->  

	      	<div class="col-two tab-1-3 mob-1-2 social-links">

	      		<h4>Social</h4>

	      		<ul>
	      			<li><a href="#">Twitter</a></li>
						<li><a href="#">Facebook</a></li>
						<li><a href="#">Dribbble</a></li>
						<li><a href="#">Google+</a></li>
						<li><a href="#">Skype</a></li>
					</ul>
	      	           	
	      	</div> <!-- /social --> 

	      	<div class="col-four tab-1-3 mob-full footer-subscribe">

	      		<h4>Subscribe</h4>

	      		<p>Keep yourself updated. Subscribe to our newsletter.</p>

	      		<div class="subscribe-form">
	      	
	      			<form id="mc-form" class="group" novalidate="true">

							<input type="email" value="" name="dEmail" class="email" id="mc-email" placeholder="type email &amp; hit enter" required=""> 
	   		
			   			<input type="submit" name="subscribe" >
		   	
		   				<label for="mc-email" class="subscribe-message"></label>
			
						</form>

	      		</div>	      		
	      	           	
	      	</div> <!-- /subscribe -->         

	      </div> <!-- /row -->

   	</div> <!-- /footer-main -->


      <div class="footer-bottom">

      	<div class="row">

      		<div class="col-twelve">
	      		<div class="copyright">
		         	<span>Copyright <%  =DateTime.Now.Year %></span> 		         			         	
		         </div>

		         <div id="go-top" style="display: block;">
		            <a class="smoothscroll" title="Back to Top" href="#top"><i class="icon ion-android-arrow-up"></i></a>
		         </div>         
	      	</div>

      	</div> <!-- /footer-bottom -->     	

      </div>

   </footer>  

   <div id="preloader"> 
    	<div id="loader"></div>
   </div> 

   <!-- Java Script
   ================================================== --> 
   <script src="js/jquery-1.11.3.min.js"></script>
   <script src="js/jquery-migrate-1.2.1.min.js"></script>
   <script src="js/plugins.js"></script>
   <script src="js/main.js"></script>

</body>

</html>
