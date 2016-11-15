<?php
		
		/*
			Hasan Yüksektepe
			www.hayatikodla.com
			hasanhasokeyk@hotmail.com
			www.facebook.com/hasokeyk
			
			Bu dosya Hayatı Kodla ya aittir.
			
		*/
		
		require "analytics.class.php";
		
		try {
      
        // sınıfı başlatalım
        $analytics = new analytics('kariyerportali@gmail.com',  'Admin123+');
        //$analytics->useCache();

        // Profil id'sini ayarlayalım
        $analytics->setProfileById('ga:133683255');

        // Tarih aralığını ayarlayalım
        $analytics->setMonth(date('n'), date('Y'));
 
		// Ziyaretçi sayısı
		$bugun = date("d");
		$sayac = $analytics->getVisitors();
		
		$date =  strtotime("last Month");
		$analytics->setMonth(date('n',$date), date('Y',$date));
		$gecenay = $analytics->getVisitors();
        
		$kelimeler = $analytics->getData(array(
											'dimensions' => 'ga:keyword',
                                            'metrics'    => 'ga:visits',
                                            'max-results'    => 12,
                                            'sort'       => 'ga:keyword'
											)
										);
		
    } catch (Exception $e) { 
        echo 'Caught exception: ' . $e->getMessage(); 
    }
	
	//Geçen ay
	$date =  strtotime("last Month");
	$gecenaykacgun = (int) date("t", $date);
	
	?>
<!DOCTYPE HTML>
<html lang="tr-TR">
<head>
	<meta charset="utf-8">
	
	<!--SEO-->
	<title>Hayatı Kodla  -  İstatistik</title>

	<!--JS-->
	<script type="text/javascript" src="http://code.jquery.com/jquery-2.0.3.js"></script>
	<script type="text/javascript" src="grafikhighcharts.js"></script>
	<script type="text/javascript" src="grafikexporting.js"></script>
	
	<!--Sayac-->
	<script type="text/javascript">
    $(function () {
    var chart;
    $(document).ready(function() {
        chart = new Highcharts.Chart({
            chart: {
                renderTo: 'sayac',
                type: 'line',
                marginRight: 120,
                marginBottom: 25
            },
            title: {
                text: 'Hayatı Kodla',
                x: -20 //center
            },
            subtitle: {
                text: 'Hayatı Kodla için Günlük Ziyaretçi Sayısı',
                x: -20
            },
            xAxis: {
                categories: [<?php 
				for($i=6; $i>0; $i--){
					
					$gunsiniri =  $gecenaykacgun+($bugun-$i);
					
					if($gunsiniri>$gecenaykacgun){
					
						$y = ($bugun-$i);
						if($y<10){
							echo "0".$y;
						}else{
							echo $y; 
						} 
						
					}else{
						echo $gunsiniri;
					}
					
					echo ",";
					
				} 
					echo $bugun; 
				?>]
            },
            yAxis: {
                title: {
                    text: 'Son 7 Gün'
                },
                plotLines: [{
                    value: 0,
                    width: 1,
                    color: '#808080'
                }]
            },
            tooltip: {
                formatter: function() {
                        return '<b>'+ this.series.name +'</b><br/>'+
                        this.x +': '+ this.y +' Kişi';
                }
            },
            legend: {
                layout: 'vertical',
                align: 'right',
                verticalAlign: 'top',
                x: -10,
                y: 100,
                borderWidth: 0
            },
            series: [{
                name: 'Ziyaret',
                data: [<?php 
				for($i=6; $i>0; $i--){
					
					$gunsiniri =  $gecenaykacgun+($bugun-$i);
					
					if($gunsiniri>$gecenaykacgun){
					
						$y = ($bugun-$i);
						if($y<10){
							echo $sayac["0".$y];
						}else{
							echo $sayac[$y]; 
						} 
						
					}else{
						echo $gecenay[$gunsiniri];
					}
					
					echo ",";
				} 
					echo $sayac[$bugun]; 
				?>]
            }]
        });
    });
});
</script>
	<!--Sayac-->
	
</head>
<body>	
	<div id="sayac"></div>
</body>
</html>