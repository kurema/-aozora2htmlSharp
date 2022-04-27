﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Aozora;
using Aozora.Helpers;
using Aozora.Helpers.Tag;

namespace TestProject;

public static class UnitTestRubyTag
{
    [Fact]
    public static void TestNew()
    {
        var tag = new Ruby("aaa", "bb");
        Assert.True(tag is Ruby);
        Assert.True(tag is Inline);
        Assert.True(tag is ReferenceMentioned);
        Assert.True(tag is IHtmlProvider);
    }

    [Fact]
    public static void TestToHtml()
    {
        var tag = new Ruby("テスト", "てすと");
        Assert.Equal("<ruby><rb>テスト</rb><rp>（</rp><rt>てすと</rt><rp>）</rp></ruby>", tag.to_html());
    }
}

