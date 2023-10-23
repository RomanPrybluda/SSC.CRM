using Bogus;
using DAL.DBContext;
using DAL.Entity;

namespace Domain.Seeds
{
    public class ContractInitializer
    {
        private readonly AppDBContext _context;

        public ContractInitializer(AppDBContext context)
        {
            _context = context;
        }

        public void InitializeContracts()
        {
            var faker = new Faker();

            var existingContractsCount = _context.Contracts.Count();

            if (existingContractsCount < 120)
            {
                var clients = _context.Clients.ToList();

                for (int i = 0; i < 120 - existingContractsCount; i++)
                {
                    var client = faker.PickRandom(clients);
                    var contractNumber = GenerateContractNumber(faker);
                    var title = GenerateEnglishTitle(faker);
                    var description = GenerateEnglishDescription(faker);

                    var contract = new Contract
                    {
                        ContractNumber = contractNumber,
                        Title = title,
                        Description = description,
                        ClientId = client.ClientId
                    };

                    _context.Contracts.Add(contract);
                }

                _context.SaveChanges();
            }
        }

        private string GenerateContractNumber(Faker faker)
        {
            string number = faker.Random.Int(1, 999).ToString("D3");
            string month = faker.Random.Int(1, 12).ToString("D2");
            string year = faker.Random.Int(2000, 2023).ToString();

            string contractNumber = $"{number}-{month}-{year}";

            return contractNumber;
        }


        private string GenerateEnglishTitle(Faker faker)
        {
            var random = new Random();
            int index = random.Next(EnglishContractTitles.Length);
            return EnglishContractTitles[index];
        }

        private string GenerateEnglishDescription(Faker faker)
        {
            var random = new Random();
            int index = random.Next(EnglishContractDescriptions.Length);
            return EnglishContractDescriptions[index];
        }

        private string[] EnglishContractTitles = new string[]
        {
            "Service Agreement",
            "Sales Contract",
            "Consulting Agreement",
            "Supply Agreement",
            "Partnership Contract",
            "Employment Contract",
            "Non-Disclosure Agreement",
            "License Agreement",
            "Lease Agreement",
            "Purchase Agreement",
            "Subcontracting Agreement",
            "Agency Agreement",
            "Distribution Agreement",
            "Franchise Agreement",
            "Joint Venture Agreement",
            "Construction Contract",
            "Software Licensing Agreement",
            "Marketing Agreement",
            "Real Estate Contract",
            "Investment Agreement",
            "Maintenance Contract",
            "Advertising Agreement",
            "Loan Agreement",
            "Research and Development Agreement",
            "Manufacturing Agreement",
            "Service Level Agreement",
            "Confidentiality Agreement",
            "Sponsorship Agreement",
            "Hiring Agreement",
            "Freelance Contract",
            "Consulting Services Agreement",
            "Technology Transfer Agreement",
            "Event Planning Contract",
            "Media Services Agreement",
            "Software Development Contract",
            "Sales and Purchase Agreement",
            "Outsourcing Agreement",
            "Rental Agreement",
            "Maintenance and Support Contract",
            "Marketing Services Agreement",
            "Investment Services Agreement",
            "Real Estate Lease Agreement",
            "Product Distribution Agreement",
            "Franchise Licensing Agreement",
            "Joint Venture Contract",
            "Construction Services Agreement",
            "Intellectual Property License Agreement",
            "Advertising Services Agreement",
            "Loan Services Agreement",
            "Research Collaboration Agreement"
        };


        private string[] EnglishContractDescriptions = new string[]
        {
            "This contract outlines the terms and conditions of the agreement between the parties.",
            "The parties agree to the following terms for the duration of this contract.",
            "This document details the scope of work, payment terms, and obligations of both parties.",
            "The contract specifies the rights and responsibilities of each party involved.",
            "In accordance with this agreement, the following terms are agreed upon.",
            "This contract covers the scope of services, fees, and deadlines for completion.",
            "The parties hereby agree to the terms and conditions set forth in this document.",
            "This agreement outlines the deliverables and payment schedule for the project.",
            "The contract defines the roles and responsibilities of each party involved.",
            "By signing this contract, the parties acknowledge and accept the terms stated herein.",
            "This document serves as a legal agreement between the parties involved.",
            "The terms of this contract are binding and enforceable by law.",
            "This agreement includes provisions for dispute resolution and termination.",
            "The contract stipulates the duration and renewal options for the agreement.",
            "The parties commit to fulfilling their obligations as specified in this contract.",
            "The terms and conditions of this agreement are designed to protect both parties' interests.",
            "This document serves as a legally binding commitment between the parties.",
            "The contract is effective from the date of signing and remains in force until termination.",
            "Both parties agree to comply with the terms and conditions outlined in this contract.",
            "This agreement includes provisions for confidentiality and data protection.",
            "The contract addresses indemnification and liability of the parties.",
            "This document outlines the process for dispute resolution and arbitration.",
            "The parties agree to resolve any disputes through negotiation and mediation.",
            "This contract includes provisions for force majeure and unforeseen circumstances.",
            "The agreement specifies the governing law and jurisdiction for legal matters.",
            "This document serves as a comprehensive understanding of the parties' obligations.",
            "The contract covers intellectual property rights and ownership of work product.",
            "Both parties acknowledge that they have read and understood the terms of this contract.",
            "The agreement may be amended with the mutual consent of both parties.",
            "This contract is a legal instrument that governs the relationship between the parties.",
            "The terms of this agreement are subject to applicable state and federal laws.",
            "The parties intend to create a legally binding commitment with this contract.",
            "This document may be executed in multiple counterparts, each of which is considered an original.",
            "The parties agree to cooperate in good faith to fulfill their obligations under this contract.",
            "This contract covers the allocation of risks and liabilities between the parties.",
            "The agreement includes provisions for the termination and expiration of the contract.",
            "The parties agree to keep all information and data confidential as per this contract.",
            "This document specifies the methods of payment and invoicing for services provided.",
            "The contract is governed by the laws of the state in which it is executed.",
            "The terms of this agreement may be enforced through legal action if necessary.",
            "The parties are responsible for any taxes or duties arising from this contract.",
            "This contract serves as the entire agreement between the parties and supersedes all prior discussions.",
            "The agreement is valid and binding upon the parties, their successors, and assigns.",
            "The contract may only be amended in writing with the consent of both parties.",
            "This document reflects the complete understanding of the parties regarding the subject matter herein.",
            "The parties agree to resolve any disputes through binding arbitration.",
            "This contract covers the protection of confidential information and trade secrets.",
            "The terms and conditions of this agreement are fair and equitable to both parties.",
            "The parties intend to create a stable and legally binding relationship with this contract."
        };
    }
}