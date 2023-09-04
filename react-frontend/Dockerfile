# Use Node image
FROM node:14

# Set working directory
WORKDIR /app

# Copy package.json and install dependencies
COPY package.json package-lock.json ./
RUN npm install

# Copy local files to container
COPY . .

# Build the React app
RUN npm run build

# Expose port
EXPOSE 3000

# Run the app
CMD ["npm", "start"]
