# Reference
## Quotes
<details><summary><code>client.Quotes.<a href="/src/YasminaaiApi/Quotes/QuotesClient.cs">ShowQuoteAsync</a>(GetQuoteRequestsIdRequest { ... }) -> WithRawResponseTask&lt;QuoteResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Quotes.ShowQuoteAsync(new GetQuoteRequestsIdRequest { Id = 1 });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetQuoteRequestsIdRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Quotes.<a href="/src/YasminaaiApi/Quotes/QuotesClient.cs">DeleteQuoteAsync</a>(DeleteQuoteRequestsIdRequest { ... }) -> WithRawResponseTask&lt;DeleteQuoteRequestsIdResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Quotes.DeleteQuoteAsync(new DeleteQuoteRequestsIdRequest { Id = 1 });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DeleteQuoteRequestsIdRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Quotes.<a href="/src/YasminaaiApi/Quotes/QuotesClient.cs">ListQuotesAsync</a>(GetQuoteRequestsRequest { ... }) -> WithRawResponseTask&lt;PaginatedQuoteResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Quotes.ListQuotesAsync(
    new GetQuoteRequestsRequest
    {
        DateFrom = new DateOnly(2026, 6, 1),
        DateTo = new DateOnly(2026, 6, 30),
        PerPage = 10,
        IncludeAggregates = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetQuoteRequestsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Quotes.<a href="/src/YasminaaiApi/Quotes/QuotesClient.cs">RequestQuotesAsync</a>(PostQuoteRequestsRequest { ... }) -> WithRawResponseTask&lt;QuoteResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

For getting prices with benefits. 
The Quote IDs can be used later to issue a policy
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Quotes.RequestQuotesAsync(
    new PostQuoteRequestsRequest
    {
        Otp = "123456",
        OwnerId = "owner_id",
        Phone = "phone",
        Birthdate = new DateOnly(2023, 1, 15),
        CarEstimatedCost = 1.1,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PostQuoteRequestsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Policies
<details><summary><code>client.Policies.<a href="/src/YasminaaiApi/Policies/PoliciesClient.cs">ShowPolicyAsync</a>(GetPoliciesCarPolicyRequest { ... }) -> WithRawResponseTask&lt;Policy&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Show a specific policy
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Policies.ShowPolicyAsync(new GetPoliciesCarPolicyRequest { CarPolicy = 1 });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetPoliciesCarPolicyRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Policies.<a href="/src/YasminaaiApi/Policies/PoliciesClient.cs">ListPoliciesAsync</a>(GetPoliciesRequest { ... }) -> WithRawResponseTask&lt;PaginatedPolicyResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Listing requested policies
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Policies.ListPoliciesAsync(
    new GetPoliciesRequest
    {
        DateFrom = new DateOnly(2026, 6, 1),
        DateTo = new DateOnly(2026, 6, 30),
        IncludeAggregates = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetPoliciesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Policies.<a href="/src/YasminaaiApi/Policies/PoliciesClient.cs">IssuePolicyAsync</a>(PostPoliciesRequest { ... }) -> WithRawResponseTask&lt;Policy&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

For issuing a new policy
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Policies.IssuePolicyAsync(
    new PostPoliciesRequest
    {
        Otp = "123456",
        QuoteRequestId = 123,
        QuoteReferenceId = "550e8400-e29b-41d4-a716-446655440000",
        QuotePriceId = "550e8400-e29b-41d4-a716-446655440001",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PostPoliciesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## OtPs
<details><summary><code>client.OtPs.<a href="/src/YasminaaiApi/OtPs/OtPsClient.cs">RequestOtpForQuoteVerificationAsync</a>(PostQuoteOtpRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This endpoint sends a one-time password (OTP) to the provided email and phone number for quote verification. It should be called before creating a quote request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.OtPs.RequestOtpForQuoteVerificationAsync(
    new PostQuoteOtpRequest
    {
        Email = "someone@example.com",
        Phone = "0501234567",
        OwnerId = "1012345678",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PostQuoteOtpRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.OtPs.<a href="/src/YasminaaiApi/OtPs/OtPsClient.cs">RequestOtpForIssuingPolicyAsync</a>(PostIssueOtpRequest { ... }) -> WithRawResponseTask</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This endpoint sends a one-time password (OTP). It should be called before issuing a policy.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.OtPs.RequestOtpForIssuingPolicyAsync(
    new PostIssueOtpRequest
    {
        Email = "someone@example.com",
        Phone = "0501234567",
        OwnerId = "1012345678",
        QuoteRequestId = 123,
        QuoteReferenceId = "550e8400-e29b-41d4-a716-446655440000",
        QuotePriceId = "550e8400-e29b-41d4-a716-446655440001",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PostIssueOtpRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

