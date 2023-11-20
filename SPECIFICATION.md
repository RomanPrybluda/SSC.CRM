
# SPECIFICATION (preliminary)

## Project Name: SSС - Ship Survey Company

---

# [UserStoryScheme](https://miro.com/app/board/uXjVNMkpgCI=/?share_link_id=729305800909)


---

# ENTITIES

### Contract - Contract for the performance of work
- Includes a description of the work that must be performed for the client company.
- Contains information about the amount for work performed.
- Includes client company details.
- Contains contact details of the person signing the contract on behalf of the client's company.
- Contains information about the contract status: not signed, signed, cancelled.

### Order 
- Includes a list of documents that must be completed.
- Contains information about the customer, whether a contract for this work has been drawn up, whether the contract for this work has been signed, whether all documents have been completed, whether all documents have been approved.
- Information about the status of the contract: not signed, signed, signed, cancelled.
- Information about the status of the application: not closed, closed, cancelled.
  
### Document
- The document has its own serial number, which includes the application number.
- An executor is assigned to the document.
- A document verifier is assigned to the document.
- Contains information about the status of the document: developer has not been assigned, developer has been appointed, in progress, being reviewed, being edited, ready to be sent to the customer, approved.
- Contains information about the availability of necessary documentation for the development of a document received from the customer.
  
### Invoice 
- Information about the client company
- Contract number
- The amount of payment for work performed.
	 
---

# User story

1. Managers:    
- As a manager, I want to be able to log in to access all sections of the site.
- As a manager, I want to be able to create new requests to initiate survey work.
- As a manager, I want to be able to appoint responsible surveyors to carry out applications.
- As a manager, I want to be able to create and edit contracts with clients.
       
2. Accountant:    
- As an accountant, I want to have access to all sections of the site to manage financial data.
- As an accountant, I want to be able to create and edit client agreements to ensure financial data is up to date.

3. Senior surveyors:    
- As the Principal Surveyor, I want to be able to create new documents within the application to begin the survey process.
- As the Chief Surveyor, I want to be able to assign responsible staff (junior surveyors) to perform specific tasks in the application.
  
4. Junior surveyors:    
- As a junior surveyor, I want to have access to all sections except the Contract and Accounting sections.
- As a junior surveyor, I want to be able to work with documents and tasks assigned by the chief surveyors.
  
5. Super admin:
- As a super administrator, I want to have full access to the site's administrative panel to manage users, roles and system settings.
- As a super administrator, I want to be able to monitor user activity and ensure system security.

These are basic User stories, they can be changed and supplemented during the project.

---

# Endpoints by ROLE

1. Managers:
     - `POST /api/login`: User authentication.
     - `GET /api/requests`: Receiving a list of requests.
     - `POST /api/requests`: Create a new request.
     - `PUT /api/requests/{id}/assign`: Assignment of responsible surveyors for the application.
     - `POST /api/contracts`: Create a new contract.
     - `PUT /api/contracts/{id}`: Editing an existing contract.

2. Accountant:
     - `GET /api/contracts`: Retrieving a list of contracts.
     - `POST /api/contracts`: Create a new contract.
     - `PUT /api/contracts/{id}`: Editing an existing contract.

3. Main surveyors:
     - `POST /api/requests/{id}/documents`: Creation of new documents within the application.
     - `PUT /api/requests/{id}/assign`: Assignment of responsible junior surveyors to perform tasks in the application.

4. Junior surveyors:
     - `GET /api/requests/{id}/documents`: Receiving a list of documents in the application.
     - `PUT /api/documents/{id}`: Editing an existing document.
    
1. Super admin:
     - `GET /api/users`: Retrieving a list of users.
     - `POST /api/users`: Create a new user.
     - `PUT /api/users/{id}`: Editing user data.
     - `DELETE /api/users/{id}`: Deleting a user.
     - `GET /api/roles`: Retrieving a list of roles.
     - `POST /api/roles`: Create a new role.
     - `PUT /api/roles/{id}`: Editing a role.
     - `DELETE /api/roles/{id}`: Deleting a role.

This is a basic set of endpoints; they can be changed and supplemented during the project.
Authentication and authorization for different categories of users will also be added.

---

# Endpoints by Entity

1. Applications:

    - `GET /api/requests`: Retrieving a list of all requests.
    - `GET /api/requests/{request_id}`: Receiving information about a specific request by identifier.
    - `POST /api/requests`: Create a new request.
    - `PUT /api/requests/{request_id}`: Update information about the request.
    - `DELETE /api/requests/{request_id}`: Deleting a request.

2. Documents in the application:

    - `GET /api/requests/{request_id}/documents`: Receiving a list of documents in the application.
    - `GET /api/requests/{request_id}/documents/{document_id}`: Retrieving information about a specific document in the request.
    - `POST /api/requests/{request_id}/documents`: Create a new document in the request.
    - `PUT /api/requests/{request_id}/documents/{document_id}`: Update information about the document in the request.
    - `DELETE /api/requests/{request_id}/documents/{document_id}`: Deleting a document in a request.

3. Agreements:

    - `GET /api/contracts`: Retrieving a list of all contracts.
    - `GET /api/contracts/{contract_id}`: Retrieving information about a specific contract by identifier.
    - `POST /api/contracts`: Create a new contract.
    - `PUT /api/contracts/{contract_id}`: Update contract information.
    - `DELETE /api/contracts/{contract_id}`: Deleting a contract.

4. Client companies:

    - `GET /api/clients`: Retrieving a list of all client companies.
    - `GET /api/clients/{client_id}`: Retrieving information about a specific client company by identifier.
    - `POST /api/clients`: Create a new client company.
    - `PUT /api/clients/{client_id}`: Update information about the client company.
    - `DELETE /api/clients/{client_id}`: Deleting a client company.

5. Contact persons of client companies:

    - `GET /api/clients/{client_id}/contacts`: Retrieving a list of contact persons for the client company.
    - `GET /api/clients/{client_id}/contacts/{contact_id}`: Retrieving information about a specific contact person by identifier.
    - `POST /api/clients/{client_id}/contacts`: Create a new contact person.
    - `PUT /api/clients/{client_id}/contacts/{contact_id}`: Update information about the contact person.
    - `DELETE /api/clients/{client_id}/contacts/{contact_id}`: Deleting a contact person.

---

# Endpoints by Service

1. **UserService**:

    - `POST /api/auth/login`: User authentication.
    - `POST /api/auth/register`: Registering a new user.
    - `GET /api/users`: Retrieving a list of users.
    - `GET /api/users/{user_id}`: Retrieving information about a specific user.
    - `PUT /api/users/{user_id}`: Update user information.
    - `DELETE /api/users/{user_id}`: Deleting a user.

2. **RequestService**:

    - `GET /api/requests`: Retrieving a list of all requests.
    - `GET /api/requests/{request_id}`: Retrieving information about a specific request.
    - `POST /api/requests`: Create a new request.
    - `PUT /api/requests/{request_id}`: Update information about the request.
    - `DELETE /api/requests/{request_id}`: Deleting a request.

3. **DocumentService**:

    - `GET /api/documents`: Retrieving a list of all documents.
    - `GET /api/documents/{document_id}`: Retrieving information about a specific document.
    - `POST /api/documents`: Create a new document.
    - `PUT /api/documents/{document_id}`: Update document information.
    - `DELETE /api/documents/{document_id}`: Deleting a document.

4. **ContractService**:

    - `GET /api/contracts`: Retrieving a list of all contracts.
    - `GET /api/contracts/{contract_id}`: Retrieving information about a specific contract.
    - `POST /api/contracts`: Create a new contract.
    - `PUT /api/contracts/{contract_id}`: Update contract information.
    - `DELETE /api/contracts/{contract_id}`: Deleting a contract.

5. **ClientService**:

    - `GET /api/clients`: Retrieving a list of all client companies.
    - `GET /api/clients/{client_id}`: Retrieving information about a specific client company.
    - `POST /api/clients`: Create a new client company.
    - `PUT /api/clients/{client_id}`: Update information about the client company.
    - `DELETE /api/clients/{client_id}`: Deleting a client company.

6. **ContactService**:

    - `GET /api/clients/{client_id}/contacts`: Retrieving a list of contact persons for the client company.
    - `GET /api/clients/{client_id}/contacts/{contact_id}`: Retrieving information about a specific contact person.
    - `POST /api/clients/{client_id}/contacts`: Create a new contact person.
    - `PUT /api/clients/{client_id}/contacts/{contact_id}`: Update information about the contact person.
    - `DELETE /api/clients/{client_id}/contacts/{contact_id}`: Deleting a contact person.

7. **AssignmentService**:

    - `POST /api/assignments`: Create a new assignment for an application or document.
    - `PUT /api/assignments/{assignment_id}`: Update assignment information.
    - `DELETE /api/assignments/{assignment_id}`: Deleting an assignment.

8. **AuditService**:

    - `GET /api/audit-logs`: Retrieving the system event audit log.

9. **NotificationService**:

    - `GET /api/notifications`: Receive notifications for the current user.
    - `POST /api/notifications`: Sending a notification.

10. **ReportService**:

     - `GET /api/reports`: Request to generate reports with various parameters.

11. **AuthorizationService**:

     - `POST /api/auth/token`: Request to obtain a token for authenticating API requests.

12. **FileService**:

     - `POST /api/files/upload`: Uploading files to the server.
     - `GET /api/files/{file_id}`: Download a file.

13. **EmailService**:

     - `POST /api/emails/send`: Sending emails.

14. **SettingsService**:

     - `GET /api/settings`: Retrieving system settings.
     - `PUT /api/settings`: Update system settings.

15. **LocalizationService**:

     - `GET /api/localization`: Receive localized texts and messages to support different languages.

16. **SecurityService**:

     - This service may provide security features such as encryption and attack protection, but does not necessarily have separate endpoints.
   
---

# SERVICEs

When dividing the backend part of the project into three projects (DAL, Domain, WebAPI), services are usually located in the Services folder of the Domain project. Here is a list of typical services that can be placed in the Services folder:

1. **UserService**: User management, including authentication, authorization, role management and access rights.

2. **RequestService**: Manage requests, including creating, updating, deleting and searching requests.

3. **DocumentService**: Document management, including creating, updating, deleting and searching documents.

4. **ContractService**: Contract management, including creating, updating, deleting and searching for contracts.

5. **ClientService**: Manage client companies, including creating, updating, deleting and searching client companies.

6. **ContactService**: Manage contacts of client companies, including creating, updating, deleting and searching contacts.

7. **AssignmentService**: Manage assignments and responsible persons for applications and documents.

8. **AuditService**: Logging of user actions and auditing of system events.

9. **NotificationService**: Manage notifications and alerts to users about events in the system.

10. **ReportService**: Generate and provide reports and statistics to users.

11. **AuthorizationService**: Service for managing authorization and generating tokens for authenticating API requests.

12. **FileService**: File management and document storage.

13. **EmailService**: Send emails and manage email notifications.

14. **SettingsService**: Manage system settings and configuration.

15. **LocalizationService**: Localization of text messages and interface to support different languages.

16. **SecurityService**: Security measures such as data encryption, attack protection and exception handling.

---

# UI Design Technical Specifications

#### Scenarios for such users:
1) SuperAdmin
2) Director
3) Manager
4) Accountant
5) Senior Surveyor
6) Middle Surveyor
7) Junior Surveyor

#### General user pages:
1) Register page
2) Login Page
3) Register Confirm Page
4) Success conformation page
5) Forgot Password Page
6) Password Recovery Page

### View pages
1) dashboards for each user (like main page)
2) page with client list
3) page with order list
4) order page with documents and information

#### Create pages
1) Create client with contact person
2) Create contract
3) Create invoice
4) Create order
5) Create document
6) Create ship
**NOTE**: Depending on the design of the viewing pages, these windows may not be needed.  


Please provide the page design on the resource:
[Figma](https://www.figma.com)


