
    var citiesByState = {
            AndhraPradesh: ["Visakhapatnam", "Vijayawada", "Guntur", "Tirupati", "Nellore"],
            ArunachalPradesh: ["Itanagar", "Naharlagun"],
            Assam: ["Guwahati", "Silchar", "Dibrugarh", "Jorhat", "Nagaon"],
            Bihar: ["Patna", "Gaya", "Bhagalpur", "Muzaffarpur", "Darbhanga"],
            Chhattisgarh: ["Raipur", "Bilaspur", "Bhilai", "Korba", "Durg"],
            Goa: ["Panaji", "Margao", "Vasco da Gama", "Mapusa"],
            Gujarat: ["Ahmedabad", "Surat", "Vadodara", "Rajkot", "Gandhinagar"],
            Kerala: ["Thiruvananthapuram", "Kochi Cochin", "Kozhikode Calicut", "Thrissur", "Kollam"],
            Tamilnadu: ["Chennai", "Coimbatore", "Madurai", "Tiruchirappalli Trichy", "Salem"]
        }
    function makeSubmenu(value) {
            if (value.length == 0)
                    document.getElementById("city").innerHTML = "<option></option>";
            else
            {
                var citiesOptions = "";
                for (cityId in citiesByState[value]) 
                {
                    citiesOptions += "<option>" + citiesByState[value][cityId] + "</option>";
                }
                document.getElementById("city").innerHTML = citiesOptions;
            }
        }

    function resetSelection() {
        document.getElementById("states").selectedIndex = 0;
        document.getElementById("city").selectedIndex = 0;
        }
