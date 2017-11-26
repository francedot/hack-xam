<html lang="en">

<head>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
	<!--<meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../../../../favicon.ico">-->

	<title>EyeCare - Elsevier Research</title>

	<!-- Bootstrap core CSS -->
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/css/bootstrap.min.css" integrity="sha384-PsH8R72JQ3SOdhVi3uxftmaW6Vc51MKb0q5P2rRUpPvrszuE4W1povHYgTpBfshb" crossorigin="anonymous">

	<!-- Custom styles for this template -->
	<link href="style.css" rel="stylesheet">
</head>

<body>
	
	<!--
	https://api.elsevier.com/content/search/scidir?apiKey=818f8ba625e9bb3df247058b5930fb5a&query=query
	-->

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
						<a class="nav-link" href="index.php">Diagnoses</a>
					</li>
					<li class="nav-item">
						<a class="nav-link">Elsevier <span class="sr-only">(current)</span></a>
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
		<div class="container">
		<div class="text-center">
		<img src="/assets/elsevier-logo.svg" class="img-fluid" style="max-height: 150px">
			</div>
		<form method="post" style="padding-top: 25px;">
		<?php $query=$_POST['query']; ?>
		<input autofocus class="form-control" id="query" name="query" placeholder="Enter your query..." value="<?php echo $query?>">
		<br>
		<button type="submit" class="btn btn-primary">Search on Elsevier</button>
			</form>
			<?php
			if(!empty($query)) {
				$json = file_get_contents('https://api.elsevier.com/content/search/scidir?apiKey=818f8ba625e9bb3df247058b5930fb5a&query='.$query);
				$results = json_decode($json, true);
				$results = $results['search-results'];
				echo('<table class="table table-striped"><tr><th>Publication title</th><th>Link</th></tr>');
				foreach($results['entry'] as $entry) {
					$links = $entry['link'];
					foreach($links as $link) {
						if($link['@ref'] = 'scidir') {
							$url = $link['@href'];
						}
					}
					echo ('<tr><td>'.$entry['dc:title'].'</td><td><a target="_blank" class="btn btn-default" href="'.$url.'">Visit</a></td></tr>');
				}
				echo('</table>');
			}
			?>
		</div>
	</main>
	<!-- /.container -->
	
	<!-- Bootstrap core JavaScript
    ================================================== -->
	<!-- Placed at the end of the document so the pages load faster -->
	<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
	<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>

</body>
</html>