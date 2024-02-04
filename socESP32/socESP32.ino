#include <Wire.h> 
#include <LiquidCrystal_I2C.h>
#include <Adafruit_Sensor.h>
#include <DHT.h>
#include <Q2HX711.h>
#include <Average.h>
#include <string.h>

//firebase
#include <WiFi.h>                                                
#include <IOXhop_FirebaseESP32.h>  
#define FIREBASE_Host "https://iot-meteorologicka-stanica-default-rtdb.europe-west1.firebasedatabase.app"                   // replace with your Firebase Host
#define FIREBASE_authorization_key "92Avq34xTQN38jJarUvcfrj7mzpHOzXj6HenJSOd" // replace with your secret key
#define WIFI_SSID "IT-IQ-CREW24"       // replace with your SSID
#define WIFI_PASSWORD "hackedBYdudesek"          //replace with your Password




#define DHT_PIN 14        // Pin number for DHT11 sensor
#define DHT_TYPE DHT11    // Type of DHT sensor

#define LIGHT_PIN 34      // Pin number for TEMT6000 sensor
#define MPS_OUT_PIN 35     // OUT data pin for MPS20N0040D-D sensor
#define MPS_SCK_PIN  32    // Clock data pin for MPS20N0040D-D sensor

DHT dht(DHT_PIN, DHT_TYPE);  // Create DHT object
Q2HX711 MPS20N0040D(MPS_OUT_PIN, MPS_SCK_PIN); // Create Q2HX711 object for MPS20N0040D-D sensor
Average<long> ave(10); // Average buffer size for MPS20N0040D-D sensor

int lightValue = 0;          // Variable to store light sensor value
float pressureValue = 0;    // Variable to store pressure sensor value
float temperatureValue = 0; // Variable to store temperature value
int humidityValue = 0;    // Variable to store humidity value
LiquidCrystal_I2C lcd(0x27, 16, 2); 

void setup() {
  Serial.begin(115200); // Start serial communication
  pinMode(LIGHT_PIN, INPUT);
  dht.begin();          // Start DHT sensor
  lcd.init();  
  lcd.backlight();
  lcd.clear();
  WiFi.begin(WIFI_SSID, WIFI_PASSWORD);
  while (WiFi.status() != WL_CONNECTED){
    Serial.print(".");
    delay(300);
  }
  Serial.println();
  Serial.print("Connected with IP: ");
  Serial.println(WiFi.localIP());
  Serial.println();

  Firebase.begin(FIREBASE_Host, FIREBASE_authorization_key);                                       // connect to firebase

}

void loop() {
  // Read temperature and humidity from DHT sensor
  temperatureValue = dht.readTemperature();
  humidityValue = dht.readHumidity();

  // Read light value from TEMT6000 sensor
  float sensor_value = analogRead(LIGHT_PIN); // Get raw sensor reading
  float volts = sensor_value * 5 / 1024.0;    // Convert reading to voltage
  float amps = volts / 10000.0;             // Convert to amps across 10K resistor
  float microamps = amps * 1000000.0;             // Convert amps to microamps
  lightValue = microamps * 2.0;                  // 2 microamps = 1 lux

  // Read pressure value from MPS20N0040D-D sensor
  ave.push(MPS20N0040D.read()); // Read raw pressure sensor reading and add to average buffer
  pressureValue = ave.mean()/8950;  // Calculate average pressure value from buffer


  lcd.clear();
  lcd.print("T:");
  lcd.print(temperatureValue);
  lcd.print(" L:");
  lcd.print(lightValue);
  lcd.setCursor(0, 1);
  lcd.print("H:");
  lcd.print(humidityValue);
  lcd.print(" P:");
  lcd.print(pressureValue);
  
  Firebase.setString("RealTime/Temperature", String(temperatureValue));  
  Firebase.setString("RealTime/Humidity", String(humidityValue));
  Firebase.setString("RealTime/Pressure", String(pressureValue));
  Firebase.setString("RealTime/LightLevel", String(lightValue));
  delay(100); // Delay for 0.1 second
  Serial.println("Succesfull loop");
}
