<html lang="en">

<head>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
	<!--<meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../../../../favicon.ico">-->

	<title>EyeCare - Doctor Portal</title>

	<!-- Bootstrap core CSS -->
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/css/bootstrap.min.css" integrity="sha384-PsH8R72JQ3SOdhVi3uxftmaW6Vc51MKb0q5P2rRUpPvrszuE4W1povHYgTpBfshb" crossorigin="anonymous">

	<!-- Flakes -->
	<link rel="stylesheet" type="text/css" href="/assets/css/flakes/all.css">
	<link rel="stylesheet" type="text/css" href="/assets/css/flakes/preview.css">

	<!-- Custom styles for this template -->
	<link href="style.css" rel="stylesheet">
</head>

<body>

	<nav class="navbar navbar-expand-md fixed-top">
		<div class="container">
			<a class="navbar-brand" href="index.php">
    <img src="/assets/brand/logo.svg" width="30" height="30" alt=""> EyeCare</a>
		
			<button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarsExampleDefault" aria-controls="navbarsExampleDefault" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
		

			<div class="collapse navbar-collapse" id="navbar">
				<ul class="navbar-nav mr-auto">
					<li class="nav-item active">
						<a class="nav-link">Diagnoses <span class="sr-only">(current)</span></a>
					</li>
					<li class="nav-item">
						<a class="nav-link" href="elsevier.php">Elsevier</a>
					</li>
					<li class="nav-item dropdown">
						<a class="nav-link dropdown-toggle" href="http://example.com" id="dropdown01" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Doctor</a>
						<div class="dropdown-menu" aria-labelledby="dropdown01">
							<a class="dropdown-item" href="#">Profile</a>
							<a class="dropdown-item" href="#">Logout</a>
						</div>
					</li>
				</ul>
			</div>
		</div>
	</nav>

	<main role="main" class="container">
		<div class="flakes-content">
			<div class="view-wrap">
				<h1>Diagnoses list</h1>
				<br>
				<div id="inventory-search">
					<div class="flakes-search">
						<input class="search-box search" placeholder="Search for people..." autofocus>
					</div>
					<table class="flakes-table">
						<colgroup>
							<col span="1" style="width:20%"/>
							<col span="1" style="width:80%"/>
						</colgroup>
						<thead>
							<tr>
								<td class="id">ID</td>
								<td class="name">Name</td>
							</tr>
						</thead>
						<tbody class="list">
							<tr>
								<td class="ID"><a href="diagnosis.php">1</a>
								</td>
								<td class="name"><a href="diagnosis.php">Francesco Bonacci</a>
								</td>
							</tr>
							<tr>
								<td class="ID"><a href="diagnosis.php">2</a>
								</td>
								<td class="name"><a href="diagnosis.php">Enzo Gorlomi</a>
								</td>
							</tr>
							<tr>
								<td class="ID"><a href="diagnosis.php">3</a>
								</td>
								<td class="name"><a href="diagnosis.php">Mario Rossi</a>
								</td>
							</tr>
							<tr>
								<td class="ID"><a href="diagnosis.php">4</a>
								</td>
								<td class="name"><a href="diagnosis.php">Raffaele Aldrigo</a>
								</td>
							</tr>
							<tr>
								<td class="ID"><a href="diagnosis.php">5</a>
								</td>
								<td class="name"><a href="diagnosis.php">Gennaro Esposito</a>
								</td>
							</tr>
						</tbody>
					</table>
					<div class="flakes-pagination right">
						<a href="">Prev</a> &nbsp; <input value="1"> <i>of</i> 3 &nbsp; <a href="">Next</a>
					</div>
				</div>
			</div>
		</div>
	</main>
	<!-- /.container -->

	<!-- Flakes CSS -->
	<link rel="stylesheet" type="text/css" href="http://getflakes.com/static/bower_components/prism/themes/prism.css">
	<link rel="stylesheet" type="text/css" href="http://getflakes.com/static/bower_components/gridforms/gridforms/gridforms.css">

	<!-- Bootstrap core JavaScript
    ================================================== -->
	<!-- Placed at the end of the document so the pages load faster -->
	<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
	<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>

	<!-- Flakes JS-->
	<script src="/assets/js/jquery.js"></script>
	<script src="/assets/js/snap.js"></script>
	<script src="/assets/js/responsive-elements.js"></script>
	<script src="/assets/js/gridforms.js"></script>
	<script src="/assets/js/prism.js"></script>
	<script src="http://getflakes.com/static/flakes/js/base.js"></script>
	<script src="http://getflakes.com/static/flakes/js/utils.js"></script>
	<script src="http://getflakes.com/static/bower_components/list.js/dist/list.js"></script>
	<script type="text/javascript" src="http://getflakes.com/static/js/preview.js"></script>
</body>

</html>