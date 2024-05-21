#FROM node:18.15.0 AS build

#USER root
#WORKDIR /app

# Instalar las dependencias del proyecto
#COPY package.json ./package.json
#COPY package-lock.json ./package-lock.json

# Copiar los archivos del proyecto
#COPY . ./

#Actualizo el kernel (SO) e instalo paquetes globales requeridos
#RUN wget -q -O - https://dl-ssl.google.com/linux/linux_signing_key.pub | apt-key add -
#RUN echo "deb http://dl.google.com/linux/chrome/deb/ stable main" > /etc/apt/sources.list.d/google.list
#RUN apt-get update
#RUN apt-get install -y google-chrome-stable xvfb
#RUN apt-get install -y git curl zip unzip jq
#RUN curl "https://awscli.amazonaws.com/awscli-exe-linux-x86_64.zip" -o "awscliv2.zip" && unzip awscliv2.zip && ./aws/install

#Instalo las dependencias y framework 'ng' del proyecto requeridos
#RUN npm install -g @angular/cli
#RUN npm install

#Construir el proyecto de Angular
#RUN ng build

#Imagen final de docker que se utilizará en el despliegue
FROM nginx:1.13.9-alpine AS base
#Use a volume is mor efficient and speed that filesystem
VOLUME /tmp
#Borro los ficheron por default en la ruta del Apache Nginx
RUN rm -rf /usr/share/nginx/html/*

#FROM build AS final
#WORKDIR /app
#Copio la salida del proyecto en la ruta del Apache Nginx
COPY ECommerce.Frontend/dist/angular-solid/ /usr/share/nginx/html

# Copiar la configuración de nginx dentro del contenedor
COPY ECommerce.Frontend/nginx.conf /etc/nginx/conf.d/default.conf

CMD ["nginx", "-g", "daemon off;"]
#ENTRYPOINT ["ng", "serve"]
