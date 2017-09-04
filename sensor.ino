#include "application.h"
double lightValue=0.0;
double tempValue=0.0;
int motionValue=0;

//I2C library
void setup(){

Serial.begin(9600);
Wire.begin();
pinMode(A0, INPUT);
pinMode(A1, INPUT);
pinMode(D2, INPUT);

}
void loop()
{
tempValue= analogRead(A1);
double tempData=((tempValue* 3.3)/4095) * 100;
lightValue = analogRead(A0);
motionValue=digitalRead(D2);
time_t time = Time.now();
Particle.publish("temperature", String(tempData));
Particle.publish("light", String(lightValue));
Particle.publish("motion", String(motionValue));
Particle.publish("time", String(Time.format(time, TIME_FORMAT_ISO8601_FULL)));
//Particle.variable("tempValue", &temp, DOUBLE);
//Particle.variable("lightValue", &lightValue, DOUBLE);
//Particle.variable("motionValue", &motion, INT);
Serial.println(Time.format(time, TIME_FORMAT_ISO8601_FULL));
Serial.print("light value is:");
Serial.print(lightValue);
Serial.print("\n\r");
Serial.print("motion value is:");
Serial.print(motionValue);
Serial.print("\n\r");
Serial.print("temp value is:");
Serial.print(tempData);
Serial.print("\n\r");
delay(300000);

}
