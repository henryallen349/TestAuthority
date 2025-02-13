using Org.BouncyCastle.Asn1.X509;

namespace TestAuthority.Domain.Models;

/// <summary>
/// Signer information.
/// </summary>
/// <param name="CertificateChain"></param>
public record CertificateSignerInfo(List<CertificateWithKey> CertificateChain)
{
    public X509Name? Subject => CertificateChain.First().Certificate.SubjectDN;

    /// <summary>
    /// Chain of the certificates with keys.
    /// </summary>
    /// <remarks>
    /// The first element of the list is a certificate used to sign certificates and crls.
    /// The last element is the root certificate.
    /// If the list contains only one certificate, then the root certificate will be used to sign end certifcates.
    /// Elements [1..n-1] are intermediate certificates.
    /// </remarks>
    public List<CertificateWithKey> CertificateChain { get; } = CertificateChain;
}
