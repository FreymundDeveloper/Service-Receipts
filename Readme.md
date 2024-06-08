# Service-Receipts

An application for managing the flow of data related to a computer store. The application records data related to services performed in that store, dividing the data between a descriptive table and a financial content table.

Some tecnologies used:

* C#;
* ASP.NET CORE(3.1.x);
* Entity Framework;
* .NET(8.x);
* Sqlite;
* Swagger;
* Nuxt(2.x);
* Vue(2.7.x);
* HTML;
* Vuetify(2.6.x);

## API Routes

Backend with the execution port being "localhost:7136" and the Frontend with the execution port being "localhost:3000". Backend routes are specified below:

* Swagger Documentation - /swagger;

* Historic Get All - Api/Historic;
* Historic Get One - Api/Historic/:id - Parms: { "id": number };
* Historic Post - Api/Historic - Body: { "description": string, "serviceDate": Date("yyyy-mm-dd"), "serviceType": number, "receipt": { "cost": number, "amountCharged": number } };
* Historic Put - Api/Historic/:id - Parms: { "id": number } - Body: ...;
* Historic Delete - Api/Historic/:id - Parms: { "id": number };

* Receipt Get All - Api/Receipt;

## Running the App

To run the backend, it is recommended to use Microsoft VS. While the frontend can be run using the commands below:

**Obs**: Make sure the Backend is running before starting the Frontend, otherwise bugs may occur;

```bash
# install dependencies
$ npm install

# serve with hot reload
$ npm run dev

# build for production and launch server
$ npm run build
$ npm run start
```