<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>


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
	         <a href="/">Shuseki</a>
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

	            	 <h3 class="h05">Diseño Simple</h3>

		            <p>Gestione las entradas y salidas de sus empleados mediante una interfaz simple y amigable, accesible desde cualquier lugar usando computador de escritorio o móvil.
	         		</p>
	         		
	         	</div> 	         	 

				</div> <!-- /bgrid -->

				<div class="bgrid feature">	

					<span class="icon"><i class="icon-eye"></i></span>                          

	            <div class="service-content">	
	            	<h3 class="h05">Asistencia Empleados Remotos</h3>  

		            <p>Valide la productividad de sus empleados remotos y controle su asistencia laboral de una forma mas estructurada.
	         		</p>

	         		
	            </div>	                          

			   </div> <!-- /bgrid -->

			   <div class="bgrid feature">

			   	<span class="icon"><i class="icon-paint-brush"></i></span>		            

	            <div class="service-content">
	            	<h3 class="h05">Diseño Personalizable</h3>

		            <p>Personalice la interfaz, utilice los logotipos de su empresa.
	        			</p> 

	        			
	            </div> 	            	               

			   </div> <!-- /bgrid -->

				<div class="bgrid feature">

					<span class="icon"><i class="icon-file"></i></span>	              

	            <div class="service-content">
	            	<h3 class="h05">Reportes</h3>

		            <p>Imprima reportes mensuales de las horas laboradas por sus empleados remotos.
	         		</p> 

	         		
	            </div>                

				</div> <!-- /bgrid -->

			   <div class="bgrid feature">

			   	<span class="icon"><i class="icon-layers"></i></span>	            

	            <div class="service-content">	
	            	<h3 class="h05">Productividad</h3>

		            <p>El sistema tomara capturas de pantalla, ubicación geográfica, procesos y navegacion periodicamente para su posterior fiscalización.
	        			</p> 

	        			
	            </div>	               

			   </div> <!-- /bgrid -->

			   <div class="bgrid feature">

			   	<span class="icon"><i class="icon-gift"></i></span>	   	           

	            <div class="service-content">
	            	 <h3 class="h05">Control de permisos laborales</h3>

		            <p>Lleve un control de permisos solicitados por sus empleados, podran solicitarlos desde su terminal y verificar si fueron aprobados.
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

   			<p class="lead">Puede contratar cualquier de los planes que mejor se ajuste a su empresa y podra cancelar la subcripción cuando lo deseé.</p>

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
		               <p class="price-meta"></p>

	            	</div>                

	               <div class="bottom-part">

	            		<ul class="features">
		                  <li><strong>50</strong> Empleados maximos</li>
		                  <li>Monitor de entradas y salidas</li>		                  
                          <li>Monitor de productividad</li>		                                            
                          <li>Dashboard y Reportes</li>                           
                          <li>Aplicación de escritorio y móvil</li> 		                  
		               </ul>

		               <a class="button large" href="/Subscripcion?plan=1">Seleccionar</a>

	            	</div>

            	</div>           	
                        
			   </div> <!-- /price-block -->

            <div class="bgrid">

            	<div class="price-block primary">

            		<div class="top-part" data-info="recommended">

	            		<h3 class="plan-title">PYME</h3>
		               <p class="plan-price"><sup>$</sup>9.99</p>
		               <p class="price-month">Por mes</p>
							<p class="price-meta"></p>

	            	</div>               

	               <div class="bottom-part">

	            		<ul class="features">
		                  <li><strong>200</strong> Empleados maximos</li>
		                  <li>Monitor de entradas y salidas</li>		                  
                          <li>Monitor de productividad</li>		                  
                          <li>Dashboard y Reportes</li>
                          <li>Aplicación de escritorio y móvil</li>
                          <li>Soporte para instalación del sistema</li>
		               </ul>

		               <a class="button large" href="/Subscripcion?plan=2">Seleccionar</a>

	            	</div>
            		
            	</div>            	                 

			  </div> <!-- /price-block --> 
             <div class="bgrid"> 

            	<div class="price-block">

            		<div class="top-part">

	            		<h3 class="plan-title">Premium</h3>
		               <p class="plan-price"><sup>$</sup>99.9</p>
		               <p class="price-month">Por mes</p>
		               <p class="price-meta"></p>

	            	</div>                

	               <div class="bottom-part">

	            		<ul class="features">
		                  <li>Empleados <strong>Ilimitados</strong></li>
		                  <li>Monitor de entradas y salidas</li>		                  
                          <li>Monitor de productividad</li>
                          <li>Aplicación de escritorio y móvil</li>	                  
                          <li>Dashboard y Reportes</li>
                          <li>Soporte para instalación del sistema</li>
                          <li>Sistema personalizado a sus requerimientos</li>
		               </ul>

		               <a class="button large" href="/Subscripcion?plan=3">Seleccionar</a>

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
   			<h2 class="h01">Testimonios de clientes.</h2>
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
                 Cumple con lo prometido, simple y económico, le ha permitido a la empresa ahorrar miles de dolares en programadores e infraestructura.  						
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
                  Me gusta que sea personalizable permite presentarlo mas profesionalmente a los empleados y no parece que sea un servicio de terceros, es como si lo hubieran diseñado a la medida de nuestro negocio.    
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
   			<h1>Preguntas y Respuestas.</h1>

   			<p class="lead">Respuestas a las dudas mas comunes.</p>

   		</div>   		
   	</div>

   	<div class="row faq-content">

   		<div class="q-and-a block-1-2 block-tab-full group">

   			<div class="bgrid">

   				<h3>El sistema es seguro?</h3>

   				<p>Si, La aplicación cuenta con una capa de seguridad para asegurar la información recabada</p>

   			</div>

   			<div class="bgrid">

   				<h3>En que consiste la medición de productividad?</h3>

   				<p>La aplicación cliente recabara información de los empleados de forma periodica, si así lo desea, procesos activos, navegación y capturas de pantalla</p>

   			</div>

   			<div class="bgrid">

   				<h3>Puedo cancelar la subcripción?</h3>

   				<p>Si, puede cancelar cancelar su renovación desde su panel de configuración</p>

   			</div>

   			<div class="bgrid">

   				<h3>Puedo actualizar mi plan?</h3>

   				<p>Si, puede cambiar su plan desde su panel de configuración</p>

   			</div>

   			<div class="bgrid">

   				<h3>Dondé puedo descargar las aplicaciones?</h3>

   				<p>Puedes descargar las aplicaciones cliente desde esta misma pagina, solo descargue el instalador y al ejecutarlo se instalara solo</p>

   			</div>

   			<div class="bgrid">

   				<h3>Por qué dice que no estoy autorizado al ingresar?</h3>

   				<p>Solo tienen permiso de ingreso administrativo los usuarios designados al departamento administrativo, el usuario con el que se registro al servicio tiene los permisos para asignar otros usuarios al departamento administrativo</p>

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

   			<h1 class="h01">Links de descarga.</h1>

   			<p class="lead">Descarge la aplicación para su sistema:</p>

   			<ul class="stores">
   				<li class="app-store">
   					<a href="#" class="button round large" title="">
   						<i class="icon ion-social-android"></i>APK Android
   					</a>
   				</li>   				
   				<li class="windows-store">
   					<a href="/App.ashx" class="button round large" title="Instalador" target="_blank">
   						<i class="icon ion-social-windows"></i>Windows</a>
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
		        	info@shuseki.azurewebsites.net &nbsp; +503 5555-5555
		        	</p>

		      </div> <!-- /footer-info -->

	      	      	       

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
