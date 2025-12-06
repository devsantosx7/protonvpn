/*
 * Copyright (c) 2025 Proton AG
 *
 * This file is part of ProtonVPN.
 *
 * ProtonVPN is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * ProtonVPN is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with ProtonVPN.  If not, see <https://www.gnu.org/licenses/>.
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProtonVPN.Client.Logic.Users.Contracts;
using ProtonVPN.Client.Logic.Users.Contracts.Messages;

namespace ProtonVPN.Client.Logic.Users.Tests;

[TestClass]
public class LicenseVerifierTests
{
    private readonly LicenseVerifier _licenseVerifier = new();

    [TestMethod]
    [DataRow(null, null, 0, LicenseStatus.Unknown)]
    [DataRow("VPN Free", "vpnfree", 0, LicenseStatus.Free)]
    [DataRow("VPN Plus", "vpnplus", 1, LicenseStatus.Premium)]
    [DataRow("Bundle", "bundle2022", 2, LicenseStatus.Premium)]
    public void Verify_ReturnsExpectedLicenseStatus(string? title, string? name, sbyte maxTier, LicenseStatus expectedStatus)
    {
        VpnPlan plan = new(title, name, maxTier);

        LicenseStatus status = _licenseVerifier.Verify(plan);

        Assert.AreEqual(expectedStatus, status);
    }
}
