<?php
function HenkTunnusTarkistus($Tunnus){    
    // Tunnuksen Pituus
    $GLOBALS['MIKA_MENI_VAARIN'] = array();

    if(strlen($Tunnus) != 11){
        array_push($GLOBALS['MIKA_MENI_VAARIN'],'Tunnus Liian Lyhyt Tai -Pitkä');
    }

    // Onko numerot tarvittavissa kohdissa
    function IsItInt($CheckTunnus, $Min, $Max){
        if(!is_int(intval(substr($CheckTunnus,$Min,$Max))))
        {
            return false;
        }
        return true;
    }
    
    // Soittaa onkoInt functiolle
    $value = IsItInt($Tunnus, 0, 6);
    $value_2 = IsItInt($Tunnus, 7, 3);
    if(!$value_2 or !$value){
        array_push($GLOBALS['MIKA_MENI_VAARIN'],'Numerot eivät ole oikeissa kohdissa!');
    }

    // pvmäärät
    $pp = substr($Tunnus,0,2);
    $kk = substr($Tunnus,2,2);
    $GLOBALS['Vuosi'] = substr($Tunnus,4,2);

    // vuosi
    $Year = date("Y");
    $GLOBALS['Year'] = substr($Year,2,2);
    $GLOBALS['YearTunnus'] = substr($Tunnus,6,1);
    
    // Laskee iän vuositunnuksen mukaan
    function Count_Age($Merkki){
        if($Merkki == "-"){ $Amount = 100; }
        if($Merkki == "+"){ $Amount = 200; }
        if($Merkki == "A"){ $Amount = 0; }
        $_SERVER['Age'] = $GLOBALS['Year'] + $Amount - $GLOBALS['Vuosi'];
    }
    
    // Soittaa iänLaskuun
    if($GLOBALS['YearTunnus'] == "A"){       
        if($GLOBALS['Vuosi'] >= "23")
        {
            array_push($GLOBALS['MIKA_MENI_VAARIN'],'Henkilötodistus on tulevaisuudessa!');
        }
        Count_Age("A");
    }
    elseif($GLOBALS['YearTunnus'] == "-"){
        Count_Age("-");
    }
    elseif($GLOBALS['YearTunnus'] == "+"){
        Count_Age("+");
    } else {
        array_push($GLOBALS['MIKA_MENI_VAARIN'],'Väärä Vuositunnus!');
    }
    
    // Laskee matchääkö lopputunnus syntymäpv
    
    $NNNtunnus = substr($Tunnus, 7, 3);
    $TarkistusMerkki = substr($Tunnus, 10,1);
    $Tarkistettava = substr($Tunnus, 0,6) . $NNNtunnus;
    $Tarkistettava = $Tarkistettava % 31;
    
    $Numerot = array("0","1","2","3","4","5","6","7","8","9","A","B","C","D","H","J","K","L","M","N","P","R","S","T","U","V","W","X","Y");
    if($Tarkistettava > 10){
        $Tarkistettava -= 2;
    }

    if($Numerot[$Tarkistettava] != $TarkistusMerkki){
        array_push($GLOBALS['MIKA_MENI_VAARIN'],'Väärä Tarkistusmerkki!');
    } 

    // Checkkaa sukupuolen
    function Get_Sukupuoli($KolmeNumeroa){
        $var = $KolmeNumeroa % 2;   
        if($var == 0){
            $_SERVER['S_Puoli'] = "Nainen";
        } elseif($var == 1) {
            $_SERVER['S_Puoli'] = "Mies";
        }
    }

    Get_Sukupuoli($NNNtunnus);

    if(count($GLOBALS["MIKA_MENI_VAARIN"])>0){
        return false;
    }
    return true;
}
if(isset($_POST["henkTunnus"])){
    try{
        $_SERVER['IsItTrue'] = HenkTunnusTarkistus($_POST["henkTunnus"]);
    }catch (Throwable $e) {
        $IsItTrue = false;
    }
}

?>
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

<div class="input-group mb-3 card-body">
    <form action="<?php $_PHP_SELF ?>" method="POST">
        <input type="text" class="form-control" name="henkTunnus" placeholder="Henkilötunnus" aria-label="Henkilötunnus" aria-describedby="basic-addon2">
        <div class="input-group-append">
            <button class="btn btn-outline-secondary" style="margin: 2px" type="submit" id="#MyButton">Testaa</button>
        </div>
    </form>
</div>

<table class="table">
  <thead>
    <tr>
      <th scope="col">ONGELMAT</th>
      <th scope="col">VALID!/INVALID!</th>
      <th scope="col">Ikä</th>
      <th scope="col">Sukupuoli</th>
    </tr>
  </thead>
  <tbody>
    <tr>
    <td>
    <?php 
    if(isset($GLOBALS['MIKA_MENI_VAARIN']) && is_array($GLOBALS['MIKA_MENI_VAARIN']) && count($GLOBALS['MIKA_MENI_VAARIN']) > 0) {
        foreach ($GLOBALS['MIKA_MENI_VAARIN'] as $value) {
            echo $value;
            echo '</br>';
        }
    } else {
        echo 'EI MITÄÄN!';
    }
    ?>
    </td>
      <td><?php if(isset($_SERVER['IsItTrue']) && $_SERVER['IsItTrue']){echo 'VALID!'; } else {echo 'INVALID!';}?></td>
      <td><?php if(isset($_SERVER['IsItTrue']) && $_SERVER['IsItTrue']){echo $_SERVER['Age'];}?></td>
      <td><?php if(isset($_SERVER['IsItTrue']) && $_SERVER['IsItTrue']){echo $_SERVER['S_Puoli'];}?></td>
    </tr>
  </tbody>
</table>
