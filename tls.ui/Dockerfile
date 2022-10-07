# pull official base image
FROM node:16.17.1

# set working directory
WORKDIR /app

# expose port
EXPOSE 80

# add `/app/node_modules/.bin` to $PATH
ENV PATH /app/node_modules/.bin:$PATH

# install app dependencies
COPY package.json ./
COPY package-lock.json ./
RUN npm install --silent

# add app
COPY . ./

CMD ["npm", "start"]
